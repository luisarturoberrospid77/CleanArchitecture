using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.DTO.Base;
using CA.Domain.Entities;
using CA.Domain.Exceptions;
using CA.Domain.Entities.Base;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Services;
using CA.Domain.Interfaces.Management;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
    public class AssignmentOrderService : CRUDService<CommandDTO, int,
                                                    Assignment, IAssignmentRepository<PatosaDbContext>,
                                                    PatosaDbContext>, IAssignmentOrderService
    {
        private readonly IDataShapeHelper<AssignmentDTO> _dataShaperHelper;
        private readonly IArticleRepository<PatosaDbContext> _articleRepository;
        private readonly IAssignmentDetailRepository<PatosaDbContext> _asignmentDetailRepository;
        private readonly IStockArticleRepository<PatosaDbContext> _stockArticleRepository;
        public AssignmentOrderService(IMapper mapper,
                                      IUnitOfWork<PatosaDbContext> unitOfWork,
                                      IArticleRepository<PatosaDbContext> articleRepository,
                                      IAssignmentRepository<PatosaDbContext> asignmentRepository,
                                      IAssignmentDetailRepository<PatosaDbContext> asignmentDetailRepository,
                                      IStockArticleRepository<PatosaDbContext> stockArticleRepository,
                                      IDataShapeHelper<AssignmentDTO> dataShapeHelper) : base(mapper, asignmentRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; _asignmentDetailRepository = asignmentDetailRepository; _articleRepository = articleRepository; _stockArticleRepository = stockArticleRepository; }
        public async Task<Assignment> FindAssigmentAsync(int id, CancellationToken cancellationToken = default)
        {
            var _header = await FindAsync(id, cancellationToken);
            var _detail = await _asignmentDetailRepository.FilterAsync(u => u.AssignmentId == id, cancellationToken);
            _header.AssignmentDetails = _detail.ToList();
            return _header;
        }
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedAssignmentOrderAsync(int pageNumber, int pageSize, Expression<Func<Assignment, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default)
        {
            var _result = (predicate == null) ? await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken) :
                                                await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken);
            var _joinedData = _result.GroupJoin(await _asignmentDetailRepository.AllAsync(cancellationToken),
                        o => o.Id, od => od.Id, (o, od) => new { Header = o, Detail = od })
                        .Select(s => new AssignmentDTO
                        {
                            Id = s.Header.Id,
                            StoreId = s.Header.StoreId,
                            Quantity = s.Header.Quantity,
                            PurchaseSubTotal = s.Header.PurchaseSubTotal,
                            PurchaseTax = s.Header.PurchaseTax,
                            PurchaseGrandTotal = s.Header.PurchaseGrandTotal,
                            Comments = s.Header.Comments,
                            IsSystemRow = s.Header.IsSystemRow,
                            IsDeleted = s.Header.IsDeleted,
                            CreationDate = s.Header.CreationDate,
                            AccountIdCreationDate = s.Header.AccountIdCreationDate,
                            UpdateDate = s.Header.UpdateDate,
                            AccountIdUpdateDate = s.Header.AccountIdUpdateDate,
                            DeleteDate = s.Header.DeleteDate,
                            AccountIdDeleteDate = s.Header.AccountIdDeleteDate,
                            AssignmentDetails = s.Detail.Select(t => new AssignmentDetailDTO
                            {
                                Id = t.Id,
                                AssignmentId = t.AssignmentId,
                                SkuId = t.SkuId,
                                Quantity = t.Quantity,
                                PurchasePrice = t.PurchasePrice,
                                PurchaseSubTotal = t.PurchaseSubTotal,
                                PurchaseTax = t.PurchaseTax,
                                PurchaseGrandTotal = t.PurchaseGrandTotal,
                                SalePrice = t.SalePrice,
                                IsSystemRow = t.IsSystemRow,
                                AccountIdCreationDate = t.AccountIdCreationDate,
                                CreationDate = t.CreationDate,
                                AccountIdUpdateDate = t.AccountIdUpdateDate,
                                UpdateDate = t.UpdateDate,
                                AccountIdDeleteDate = t.AccountIdDeleteDate,
                                DeleteDate = t.DeleteDate
                            })
                        }).Where(u => u.IsDeleted == false).Select(s => s).ToList();
            return await _dataShaperHelper.ShapeDataAsync(_joinedData, fields);
        }
        public async Task<Assignment> InsertAssigmentAsync(CreateAssignmentDTO objDTO, CancellationToken cancellationToken = default)
        {
            var dateNow = DateTime.UtcNow;
            var parent = _mapper.Map<Assignment>(objDTO);

            /* Verifico la existencia en stock de Centro de Distribución. */
            var ifIds = objDTO.Detail.Select(r => r.SkuId).Distinct().ToList();
            var ifExistInStock = (await _stockArticleRepository.AllAsync(cancellationToken)).GroupBy(x => new { x.SkuId, x.StoreId },
                        (key, values) => new
                        {
                            SkuId = key.SkuId,
                            StoreId = key.StoreId,
                            Total = values.Sum(x => x.ItemInputQuantity)
                        }).Where(u => u.Total > 10 && u.StoreId == 0 && ifIds.Contains(u.SkuId));

            if (ifExistInStock == null || ifExistInStock.Count() == 0)
                throw new BusinessException($"There is no available stock of items to generate the store's assignment.");

            /* Calculo el detalle de los registros hijos. */
            var child = objDTO.Detail.Join(await _articleRepository.AllAsync(cancellationToken),
                            o => o.SkuId, od => od.Id,
                            (o, od) => new
                            {
                                articleDet = o,
                                articleDb = od
                            })
                            .Where(u => u.articleDb.PurchasePrice > 0 && u.articleDb.IsDeleted == false)
                            .Select(o => new AssignmentDetail
                            {
                                Id = o.articleDet.Id,
                                SkuId = o.articleDet.SkuId,
                                Quantity = o.articleDet.Quantity,
                                PurchasePrice = o.articleDb.PurchasePrice,
                                PurchaseSubTotal = o.articleDet.Quantity * o.articleDb.PurchasePrice,
                                PurchaseTax = (o.articleDet.Quantity * o.articleDb.PurchasePrice * Convert.ToDecimal(1.16)) - (Convert.ToDecimal(o.articleDet.Quantity) * o.articleDb.PurchasePrice),
                                PurchaseGrandTotal = o.articleDet.Quantity * o.articleDb.PurchasePrice * Convert.ToDecimal(1.16),
                                SalePrice = o.articleDet.SalePrice,
                                CreationDate = dateNow,
                                AccountIdCreationDate = o.articleDet.AccountIdCreationDate
                            }).ToList();

            /* Obtengo la suma total de los hijos. */
            var sumChild = child.GroupBy(l => l.AssignmentId).Select(cl => new
            {
                Quantity = cl.Sum(c => c.Quantity),
                PurchaseSubTotal = cl.Sum(c => c.PurchaseSubTotal),
                PurchaseTax = cl.Sum(c => c.PurchaseTax),
                PurchaseGrandTotal = cl.Sum(c => c.PurchaseGrandTotal)
            }).SingleOrDefault();

            parent.Quantity = sumChild.Quantity;
            parent.PurchaseSubTotal = sumChild.PurchaseSubTotal;
            parent.PurchaseTax = sumChild.PurchaseTax;
            parent.PurchaseGrandTotal = sumChild.PurchaseGrandTotal;
            parent.CreationDate = dateNow;
            parent.AssignmentDetails = child;

            /* Saving changes... */
            return await InsertAsync(parent, cancellationToken);
        }
    }
}

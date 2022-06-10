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
    public class PurchaseOrderService : CRUDService<CommandDTO, int,
                                                    Purchase, IPurchaseRepository<PatosaDbContext>,
                                                    PatosaDbContext>, IPurchaseOrderService
    {
        private readonly IDataShapeHelper<PurchaseDTO> _dataShaperHelper;
        private readonly IPurchaseDetailRepository<PatosaDbContext> _purchaseDetailRepository;
        public PurchaseOrderService(IMapper mapper,
                                    IUnitOfWork<PatosaDbContext> unitOfWork,
                                    IPurchaseRepository<PatosaDbContext> purchaseRepository,
                                    IPurchaseDetailRepository<PatosaDbContext> purchaseDetailRepository,
                                    IDataShapeHelper<PurchaseDTO> dataShapeHelper) : base(mapper, purchaseRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; _purchaseDetailRepository = purchaseDetailRepository; }
        public async Task<Purchase> FindPurchaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var _header = await FindAsync(id, cancellationToken);
            var _detail = await _purchaseDetailRepository.FilterAsync(u => u.PurchaseId == id, cancellationToken);
            _header.PurchaseDetails = _detail.ToList();
            return _header;
        }
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedPurchasesAsync(int pageNumber, int pageSize, Expression<Func<Purchase, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default)
        {
            var _result = (predicate == null) ? await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken) :
                                                await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken);
            var _joinedData = _result.GroupJoin(await _purchaseDetailRepository.AllAsync(cancellationToken),
                    o => o.Id, od => od.PurchaseId, (o, od) => new { Header = o, Detail = od })
                    .Select(s => new PurchaseDTO
                    {
                        Id = s.Header.Id,
                        SupplierId = s.Header.SupplierId,
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
                        PurchaseDetails = s.Detail.Select(t => new PurchaseDetailDTO
                        {
                            Id = t.Id,
                            PurchaseId = t.PurchaseId,
                            SkuId = t.SkuId,
                            Quantity = t.Quantity,
                            PurchasePrice = t.PurchasePrice,
                            PurchaseSubTotal = t.PurchaseSubTotal,
                            PurchaseTax = t.PurchaseTax,
                            PurchaseGrandTotal = t.PurchaseGrandTotal,
                            SalePrice = t.SalePrice,
                            IsSystemRow = t.IsSystemRow,
                            IsDeleted = t.IsDeleted,
                            CreationDate = t.CreationDate,
                            AccountIdCreationDate = t.AccountIdCreationDate,
                            UpdateDate = t.UpdateDate,
                            AccountIdUpdateDate = t.AccountIdUpdateDate,
                            DeleteDate = t.DeleteDate,
                            AccountIdDeleteDate = t.AccountIdDeleteDate
                        })
                    }).ToList();
            return await _dataShaperHelper.ShapeDataAsync(_joinedData, fields);
        }
        public async Task<Purchase> InsertPurchaseAsync(CreatePurchaseDTO objDTO, CancellationToken cancellationToken = default)
        {
            var dateNow = DateTime.UtcNow;
            var parent = _mapper.Map<Purchase>(objDTO);

            /* Calculo el detalle de los registros hijos. */
            var child = _mapper.Map<List<PurchaseDetail>>(objDTO.Detail.Select(o => new PurchaseDetail
            {
                Id = o.Id,
                SkuId = o.SkuId,
                Quantity = o.Quantity,
                PurchasePrice = o.PurchasePrice,
                PurchaseSubTotal = o.Quantity * o.PurchasePrice,
                PurchaseTax = (o.Quantity * o.PurchasePrice * Convert.ToDecimal(1.16)) - (Convert.ToDecimal(o.Quantity) * o.PurchasePrice),
                PurchaseGrandTotal = o.Quantity * o.PurchasePrice * Convert.ToDecimal(1.16),
                CreationDate = dateNow,
                AccountIdCreationDate = o.AccountIdCreationDate
            }).ToList());

            /* Obtengo la suma total de los hijos. */
            var sumChild = child.GroupBy(l => l.PurchaseId).Select(cl => new
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
            parent.PurchaseDetails = child;

            /* Saving changes... */
            return await InsertAsync(parent, cancellationToken);
        }
    }
}

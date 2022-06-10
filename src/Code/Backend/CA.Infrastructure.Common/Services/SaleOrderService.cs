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
    public class SaleOrderService : CRUDService<CommandDTO, int,
                                                Order, IOrderRepository<PatosaDbContext>,
                                                PatosaDbContext>, ISaleOrderService
    {
        private readonly IDataShapeHelper<OrderDTO> _dataShaperHelper;
        private readonly IArticleRepository<PatosaDbContext> _articleRepository;
        private readonly IOrderDetailRepository<PatosaDbContext> _orderDetailRepository;
        private readonly IStockArticleRepository<PatosaDbContext> _stockArticleRepository;
        public SaleOrderService(IMapper mapper,
                                IUnitOfWork<PatosaDbContext> unitOfWork,
                                IOrderRepository<PatosaDbContext> orderRepository,
                                IArticleRepository<PatosaDbContext> articleRepository,
                                IOrderDetailRepository<PatosaDbContext> orderDetailRepository,
                                IStockArticleRepository<PatosaDbContext> stockArticleRepository,
                                IDataShapeHelper<OrderDTO> dataShapeHelper) : base(mapper, orderRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; _orderDetailRepository = orderDetailRepository; _articleRepository = articleRepository; _stockArticleRepository = stockArticleRepository; }
        public async Task<Order> FindOrderSaleAsync(int id, CancellationToken cancellationToken = default)
        {
            var _header = await FindAsync(id, cancellationToken);
            var _detail = await _orderDetailRepository.FilterAsync(u => u.OrderId == id, cancellationToken);
            _header.OrderDetails = _detail.ToList();
            return _header;
        }
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedOrdersSaleAsync(int pageNumber, int pageSize, Expression<Func<Order, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default)
        {
            var _result = (predicate == null) ? await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken) :
                                                await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken);
            var _joinedData = _result.GroupJoin(await _orderDetailRepository.AllAsync(cancellationToken),
                    o => o.Id, od => od.OrderId, (o, od) => new { Header = o, Detail = od })
                    .Select(s => new OrderDTO
                    {
                        Id = s.Header.Id,
                        CustomerId = s.Header.CustomerId,
                        StoreId = s.Header.StoreId,
                        Quantity = s.Header.Quantity,
                        SalePrice = s.Header.SalePrice,
                        SaleSubTotal = s.Header.SaleSubTotal,
                        SaleTax = s.Header.SaleTax,
                        SaleGrandTotal = s.Header.SaleGrandTotal,
                        Comments = s.Header.Comments,
                        IsSystemRow = s.Header.IsSystemRow,
                        IsDeleted = s.Header.IsDeleted,
                        CreationDate = s.Header.CreationDate,
                        AccountIdCreationDate = s.Header.AccountIdCreationDate,
                        UpdateDate = s.Header.UpdateDate,
                        AccountIdUpdateDate = s.Header.AccountIdUpdateDate,
                        DeleteDate = s.Header.DeleteDate,
                        AccountIdDeleteDate = s.Header.AccountIdDeleteDate,
                        OrderDetails = s.Detail.Select(t => new OrderDetailDTO
                        {
                            Id = t.Id,
                            OrderId = t.OrderId,
                            SkuId = t.SkuId,
                            Quantity = t.Quantity,
                            SalePrice = t.SalePrice,
                            SaleSubTotal = t.SaleSubTotal,
                            SaleTax = t.SaleTax,
                            SaleGrandTotal = t.SaleGrandTotal,
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
        public async Task<Order> InsertOrderSaleAsync(CreateSaleDTO objDTO, CancellationToken cancellationToken = default)
        {
            var dateNow = DateTime.UtcNow;
            var parent = _mapper.Map<Order>(objDTO);

            /* Verificamos la existencia del stock en sucursal. */
            var ifIds = objDTO.SaleDetail.Select(r => r.SkuId).Distinct().ToList();
            var ifExistInStock = (await _stockArticleRepository.AllAsync(cancellationToken)).GroupBy(x => new { x.SkuId, x.StoreId },
                        (key, values) => new
                        {
                            SkuId = key.SkuId,
                            StoreId = key.StoreId,
                            Total = values.Sum(x => x.ItemInputQuantity)
                        }).Where(u => u.Total > 10 && u.StoreId == objDTO.StoreId && ifIds.Contains(u.SkuId));

            if (ifExistInStock == null || ifExistInStock.Count() == 0)
                throw new BusinessException($"There is no available stock of items to generate the customer's purchase.");

            /* Calculo el detalle de los registros hijos. */
            var child = _mapper.Map<List<OrderDetail>>(objDTO.SaleDetail.Select(o => new OrderDetail
            {
                Id = o.Id,
                SkuId = o.SkuId,
                Quantity = o.Quantity,
                SalePrice = o.SalePrice,
                SaleSubTotal = o.Quantity * o.SalePrice,
                SaleTax = (o.Quantity * o.SalePrice * Convert.ToDecimal(1.16)) - (Convert.ToDecimal(o.Quantity) * o.SalePrice),
                SaleGrandTotal = o.Quantity * o.SalePrice * Convert.ToDecimal(1.16),
                CreationDate = dateNow,
                AccountIdCreationDate = o.AccountIdCreationDate
            }).ToList());

            /* Obtengo la suma total de los hijos. */
            var sumChild = child.GroupBy(l => l.OrderId).Select(cl => new
            {
                Quantity = cl.Sum(c => c.Quantity),
                SaleSubTotal = cl.Sum(c => c.SaleSubTotal),
                SaleTax = cl.Sum(c => c.SaleTax),
                SaleGrandTotal = cl.Sum(c => c.SaleGrandTotal)
            }).SingleOrDefault();

            parent.Quantity = sumChild.Quantity;
            parent.SaleSubTotal = sumChild.SaleSubTotal;
            parent.SaleTax = sumChild.SaleTax;
            parent.SaleGrandTotal = sumChild.SaleGrandTotal;
            parent.CreationDate = dateNow;
            parent.OrderDetails = child;

            /* Saving changes... */
            return await InsertAsync(parent, cancellationToken);
        }
    }
}

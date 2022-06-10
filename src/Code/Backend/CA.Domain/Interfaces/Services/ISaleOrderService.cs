using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Entities.Base;

namespace CA.Domain.Interfaces.Services
{
    public interface ISaleOrderService
    {
        public int RowCount { get; }
        Task<Order> FindOrderSaleAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedOrdersSaleAsync(int pageNumber, int pageSize, Expression<Func<Order, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<Order> InsertOrderSaleAsync(CreateSaleDTO objDTO, CancellationToken cancellationToken = default);
    }
}

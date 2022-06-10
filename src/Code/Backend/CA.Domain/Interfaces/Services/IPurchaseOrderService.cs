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
    public interface IPurchaseOrderService
    {
        public int RowCount { get; }
        Task<Purchase> FindPurchaseAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedPurchasesAsync(int pageNumber, int pageSize, Expression<Func<Purchase, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<Purchase> InsertPurchaseAsync(CreatePurchaseDTO objDTO, CancellationToken cancellationToken = default);
    }
}

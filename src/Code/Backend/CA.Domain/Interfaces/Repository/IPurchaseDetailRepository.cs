using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;

namespace CA.Domain.Interfaces.Repository
{
    public interface IPurchaseDetailRepository<TContext> : IBaseRepository<PurchaseDetail, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<PurchaseDetail>> GetPurchaseDetailAsync(CancellationToken cancellationToken = default);
        Task<PurchaseDetail> GetPurchaseDetailAsync(int id, CancellationToken cancellationToken = default);
        Task<PurchaseDetail> SinglePurchaseDetailAsync(Expression<Func<PurchaseDetail, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<PurchaseDetail>> FilterPurchaseDetailAsync(Expression<Func<PurchaseDetail, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddPurchaseDetailAsync(PurchaseDetail obj, CancellationToken cancellationToken = default);
        Task AddRangePurchaseDetailAsync(IEnumerable<PurchaseDetail> obj, CancellationToken cancellationToken = default);
        void UpdatePurchaseDetail(PurchaseDetail obj);
        void DeletePurchaseDetail(PurchaseDetail obj);
    }
}

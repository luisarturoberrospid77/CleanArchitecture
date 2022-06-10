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
    public interface IPurchaseRepository<TContext> : IBaseRepository<Purchase, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<Purchase>> GetPurchaseAsync(CancellationToken cancellationToken = default);
        Task<Purchase> GetPurchaseAsync(int id, CancellationToken cancellationToken = default);
        Task<Purchase> SinglePurchaseAsync(Expression<Func<Purchase, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<Purchase>> FilterPurchaseAsync(Expression<Func<Purchase, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddPurchaseAsync(Purchase obj, CancellationToken cancellationToken = default);
        Task AddRangePurchaseAsync(IEnumerable<Purchase> obj, CancellationToken cancellationToken = default);
        void UpdatePurchase(Purchase obj);
        void DeletePurchase(Purchase obj);
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Repository.Base;

namespace CA.Infrastructure.Common.Repositories
{
    public class PurchaseRepository : BaseRepository<Purchase, int, PatosaDbContext>,
                                        IPurchaseRepository<PatosaDbContext>
    {
        public PurchaseRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
        public async Task AddPurchaseAsync(Purchase obj, CancellationToken cancellationToken = default) =>
            await AddAsync(obj, cancellationToken);
        public async Task AddRangePurchaseAsync(IEnumerable<Purchase> obj, CancellationToken cancellationToken = default) =>
            await AddRangeAsync(obj, cancellationToken);
        public void DeletePurchase(Purchase obj) => Delete(obj);
        public async Task<IEnumerable<Purchase>> FilterPurchaseAsync(Expression<Func<Purchase, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterAsync(predicate, cancellationToken);
        public async Task<IEnumerable<Purchase>> GetPurchaseAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
        public async Task<Purchase> GetPurchaseAsync(int id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken);
        public async Task<Purchase> SinglePurchaseAsync(Expression<Func<Purchase, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterSingleAsync(predicate, cancellationToken);
        public void UpdatePurchase(Purchase obj) => Update(obj);
    }
}

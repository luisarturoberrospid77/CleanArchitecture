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
    public class PurchaseDetailRepository : BaseRepository<PurchaseDetail, int, PatosaDbContext>,
                                                IPurchaseDetailRepository<PatosaDbContext>
    {
        public PurchaseDetailRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
        public async Task AddPurchaseDetailAsync(PurchaseDetail obj, CancellationToken cancellationToken = default) =>
            await AddAsync(obj, cancellationToken);
        public async Task AddRangePurchaseDetailAsync(IEnumerable<PurchaseDetail> obj, CancellationToken cancellationToken = default) =>
            await AddRangeAsync(obj, cancellationToken);
        public void DeletePurchaseDetail(PurchaseDetail obj) => Delete(obj);
        public async Task<IEnumerable<PurchaseDetail>> FilterPurchaseDetailAsync(Expression<Func<PurchaseDetail, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterAsync(predicate, cancellationToken);
        public async Task<IEnumerable<PurchaseDetail>> GetPurchaseDetailAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
        public async Task<PurchaseDetail> GetPurchaseDetailAsync(int id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken);
        public async Task<PurchaseDetail> SinglePurchaseDetailAsync(Expression<Func<PurchaseDetail, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterSingleAsync(predicate, cancellationToken);
        public void UpdatePurchaseDetail(PurchaseDetail obj) => Update(obj);
    }
}

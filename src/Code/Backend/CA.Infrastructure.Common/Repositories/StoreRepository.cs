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
  public class StoreRepository : BaseRepository<Store, int, PatosaDbContext>,
                                 IStoreRepository<PatosaDbContext>
  {
    public StoreRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
    public async Task AddStoreAsync(Store obj, CancellationToken cancellationToken = default) =>
      await AddAsync(obj, cancellationToken);
    public async Task AddRangeStoreAsync(IEnumerable<Store> obj, CancellationToken cancellationToken = default) =>
      await AddRangeAsync(obj, cancellationToken);
    public void DeleteStore(Store obj) => Delete(obj);
    public async Task<IEnumerable<Store>> FilterStoreAsync(Expression<Func<Store, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterAsync(predicate, cancellationToken);
    public async Task<Store> GetStoreAsync(int id, CancellationToken cancellationToken = default) =>
      await GetByIdAsync(id, cancellationToken);
    public async Task<IEnumerable<Store>> GetStoresAsync(CancellationToken cancellationToken = default) =>
      await AllAsync(cancellationToken);
    public async Task<Store> SingleStoreAsync(Expression<Func<Store, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterSingleAsync(predicate, cancellationToken);
    public void UpdateStore(Store obj) => Update(obj);
  }
}

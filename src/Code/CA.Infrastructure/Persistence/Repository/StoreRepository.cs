using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Core.Entities;
using CA.Core.Interfaces.Base;
using CA.Core.Interfaces.Repository;

using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Repository.Base;

namespace CA.Infrastructure.Persistence.Repository
{
  public class StoreRepository : BaseRepository<Store, int, PatosaDbContext>, IStoreRepository<PatosaDbContext>
  {
    public StoreRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
    public async Task AddStoreAsync(Store obj, CancellationToken cancellationToken = default) =>
      await AddAsync(obj, cancellationToken);
    public void DeleteStore(Store obj) => DeleteStore(obj);
    public async Task<IEnumerable<Store>> FilterStoreAsync(Expression<Func<Store, bool>> predicate, CancellationToken cancellationToken = default) => 
      await FilterAsync(predicate, cancellationToken);
    public async Task<Store> GetStoreAsync(int id, CancellationToken cancellationToken = default) => 
      await GetByIdAsync(id, cancellationToken);
    public async Task<IEnumerable<Store>> GetStoresAsync(CancellationToken cancellationToken = default) => 
      await AllAsync(cancellationToken);
    public void UpdateStore(Store obj) => UpdateStore(obj);
  }
}

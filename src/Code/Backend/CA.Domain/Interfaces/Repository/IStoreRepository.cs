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
  public interface IStoreRepository<TContext> : IBaseRepository<Store, TContext>
    where TContext : DbContext, new()
  {
    Task<IEnumerable<Store>> GetStoresAsync(CancellationToken cancellationToken = default);
    Task<Store> GetStoreAsync(int id, CancellationToken cancellationToken = default);
    Task<Store> SingleStoreAsync(Expression<Func<Store, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<Store>> FilterStoreAsync(Expression<Func<Store, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddStoreAsync(Store obj, CancellationToken cancellationToken = default);
    Task AddRangeStoreAsync(IEnumerable<Store> obj, CancellationToken cancellationToken = default);
    void UpdateStore(Store obj);
    void DeleteStore(Store obj);
  }
}
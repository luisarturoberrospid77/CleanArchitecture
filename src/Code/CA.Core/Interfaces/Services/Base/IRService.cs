using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CA.Core.Interfaces.Base;
using CA.Core.Interfaces.Management;

namespace CA.Core.Interfaces.Services.Base
{
  public interface IRService<TGetDto, TKey, TEntity, TRepoRead, TContext>
      where TEntity : class, IEntityBase<TKey>
      where TRepoRead : IReadRepository<TEntity, TContext>
      where TContext : DbContext, new()
  {
    Task<IEnumerable<TGetDto>> GetAll(CancellationToken cancellationToken = default);
    Task<TGetDto> FindAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TGetDto>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
  }
}

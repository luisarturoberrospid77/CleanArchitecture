using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace CA.Domain.Interfaces.Base
{
  public interface IBaseRepository<T, TContext> : IReadRepository<T, TContext>
      where T : class
      where TContext : DbContext, new()
  {
    Task AddAsync(T Entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<T> EntityList, CancellationToken cancellationToken = default);
    void Update(T Entity);
    void Delete(T entity);
  }
}

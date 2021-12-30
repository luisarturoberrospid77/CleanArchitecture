using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace CA.Core.Interfaces.Base
{
  public interface IBaseRepository<T, TContext> : IReadRepository<T, TContext>
      where T : class
      where TContext : DbContext, new()
  {
    Task AddAsync(T Entity, CancellationToken cancellationToken = default);
    void Update(T Entity);
    void Delete(T entity);
  }
}

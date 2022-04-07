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
  public class MenuRepository : BaseRepository<MenuSystem, int, PatosaDbContext>,
                                IMenuRepository<PatosaDbContext>
  {
    public MenuRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
    public async Task<IEnumerable<MenuSystem>> FilterMenuSystemAsync(Expression<Func<MenuSystem, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterAsync(predicate, cancellationToken);
    public async Task<IEnumerable<MenuSystem>> GetMenuSystemAsync(CancellationToken cancellationToken = default) =>
      await AllAsync(cancellationToken);
    public async Task<MenuSystem> SingleMenuSystemAsync(Expression<Func<MenuSystem, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterSingleAsync(predicate, cancellationToken);
    public async Task<MenuSystem> GetMenuSystemAsync(int id, CancellationToken cancellationToken = default) =>
      await GetByIdAsync(id, cancellationToken);
  }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CA.Core.Entities;
using CA.Core.Interfaces.Base;

namespace CA.Core.Interfaces.Repository
{
  public interface IMenuRepository<TContext> : IBaseRepository<MenuSystem, TContext> where TContext : DbContext, new()
  {
    Task<IEnumerable<MenuSystem>> GetMenuSystemAsync(CancellationToken cancellationToken = default);
    Task<MenuSystem> GetMenuSystemAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<MenuSystem>> FilterCategoryAsync(Expression<Func<MenuSystem, bool>> predicate, CancellationToken cancellationToken = default);
  }
}

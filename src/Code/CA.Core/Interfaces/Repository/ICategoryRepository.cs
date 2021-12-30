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
  public interface ICategoryRepository<TContext> : IBaseRepository<MenuCategory, TContext> where TContext : DbContext, new()
  {
    Task<IEnumerable<MenuCategory>> GetCategoryAsync(CancellationToken cancellationToken = default);
    Task<MenuCategory> GetCategoryAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<MenuCategory>> FilterCategoryAsync(Expression<Func<MenuCategory, bool>> predicate, CancellationToken cancellationToken = default);
  }
}

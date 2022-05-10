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
    public interface ICategoryRepository<TContext> : IBaseRepository<MenuCategory, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<MenuCategory>> GetCategoriesAsync(CancellationToken cancellationToken = default);
        Task<MenuCategory> GetCategoryAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<MenuCategory>> GetPagedCategoriesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<MenuCategory> SingleCategoryAsync(Expression<Func<MenuCategory, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<MenuCategory>> FilterCategoryAsync(Expression<Func<MenuCategory, bool>> predicate, CancellationToken cancellationToken = default);
    }
}

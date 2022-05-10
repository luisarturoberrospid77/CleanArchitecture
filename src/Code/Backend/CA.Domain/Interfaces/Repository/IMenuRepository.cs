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
    public interface IMenuRepository<TContext> : IBaseRepository<MenuSystem, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<MenuSystem>> GetMenuSystemsAsync(CancellationToken cancellationToken = default);
        Task<MenuSystem> GetMenuSystemAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<MenuSystem>> GetPagedMenuSystemsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<MenuSystem> SingleMenuSystemAsync(Expression<Func<MenuSystem, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<MenuSystem>> FilterMenuSystemAsync(Expression<Func<MenuSystem, bool>> predicate, CancellationToken cancellationToken = default);
    }
}

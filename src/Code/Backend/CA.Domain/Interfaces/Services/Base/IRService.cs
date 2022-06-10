using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Management;

namespace CA.Domain.Interfaces.Services.Base
{
    public interface IRService<TKey, TEntity, TRepoRead, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoRead : IReadRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        Task<TEntity> FindAsync(int id, CancellationToken cancellationToken = default);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetPagedAsync(int pageNumber, int pageSize, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
    }
}

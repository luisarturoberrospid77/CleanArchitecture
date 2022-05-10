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
    public interface IRService<TQueryDTO, TKey, TEntity, TRepoRead, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoRead : IReadRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        Task<TQueryDTO> FindAsync(int id, CancellationToken cancellationToken = default);
        Task<TQueryDTO> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TQueryDTO>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<TQueryDTO>> GetAllAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<TQueryDTO>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<TQueryDTO>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<TQueryDTO>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
    }
}

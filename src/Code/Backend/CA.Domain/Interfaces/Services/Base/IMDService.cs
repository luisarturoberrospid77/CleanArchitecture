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
    public interface IMDService<TQueryDTO, TKey, TEntity, TRepoAll, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoAll : IBaseRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        Task<TQueryDTO> FindAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TQueryDTO>> GetAllAsync(string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<TQueryDTO>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<TQueryDTO>> GetPagedAsync(int pageNumber, int pageSize, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<TQueryDTO>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<TQueryDTO> InsertAsync(TEntity objDTO, CancellationToken cancellationToken = default);
    }
}

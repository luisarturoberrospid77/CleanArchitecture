using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace CA.Domain.Interfaces.Base
{
    public interface IReadRepository<T, TContext>
        where T : class
        where TContext : DbContext, new()
    {
        int GetCount();
        int GetCount(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> AllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> AllAsync(string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> AllAsync(Expression<Func<T, bool>> predicate, string orderBy = null, CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<T> FilterSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate, string orderBy = null, CancellationToken cancellationToken = default);
    }
}

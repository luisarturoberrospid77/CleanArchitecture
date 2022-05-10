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
    public interface IMovementArticleRepository<TContext> : IBaseRepository<MovementArticle, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<MovementArticle>> GetMovementArticlesAsync(CancellationToken cancellationToken = default);
        Task<MovementArticle> GetMovementArticleAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<MovementArticle>> GetPagedMovementArticlesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<MovementArticle> SingleMovementArticleAsync(Expression<Func<MovementArticle, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<MovementArticle>> FilterMovementArticleAsync(Expression<Func<MovementArticle, bool>> predicate, CancellationToken cancellationToken = default);
    }
}

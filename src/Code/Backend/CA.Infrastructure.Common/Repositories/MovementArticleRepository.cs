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
    public class MovementArticleRepository : BaseRepository<MovementArticle, int, PatosaDbContext>,
                                                IMovementArticleRepository<PatosaDbContext>
    {
        public MovementArticleRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
        public async Task<IEnumerable<MovementArticle>> FilterMovementArticleAsync(Expression<Func<MovementArticle, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterAsync(predicate, cancellationToken);
        public async Task<IEnumerable<MovementArticle>> GetMovementArticlesAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
        public async Task<MovementArticle> GetMovementArticleAsync(int id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken);
        public async Task<IEnumerable<MovementArticle>> GetPagedMovementArticlesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default) =>
            await GetPagedAsync(pageNumber, pageSize, cancellationToken);
        public async Task<MovementArticle> SingleMovementArticleAsync(Expression<Func<MovementArticle, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterSingleAsync(predicate, cancellationToken);
    }
}

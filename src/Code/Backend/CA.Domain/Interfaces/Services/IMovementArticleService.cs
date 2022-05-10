using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Entities.Base;

namespace CA.Domain.Interfaces.Services
{
    public interface IMovementArticleService
    {
        public int RowCount { get; }
        Task<MovementArticleDTO> FindMovementArticleAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetMovementArticlesAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedMovementArticlesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, Expression<Func<MovementArticle, bool>> predicate = null, string fields = null, string orderBy = null);
    }
}

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
    public interface IArticleService
    {
        public int RowCount { get; }
        Task<Article> FindArticleAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetArticlesAsync(Expression<Func<Article, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedArticlesAsync(int pageNumber, int pageSize, Expression<Func<Article, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<Article> InsertArticleAsync(CreateArticleDTO objDTO, CancellationToken cancellationToken = default);
        Task<Article> UpdateArticleAsync(UpdateArticleDTO objDTO, CancellationToken cancellationToken = default);
        Task<Article> DeleteArticleAsync(DeleteArticleDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

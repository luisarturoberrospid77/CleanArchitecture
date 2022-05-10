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
        Task<ArticleDTO> FindArticleAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetArticlesAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedArticlesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, Expression<Func<Article, bool>> predicate = null, string fields = null, string orderBy = null);
        Task<CreateArticleDTO> InsertArticleAsync(CreateArticleDTO objDTO, CancellationToken cancellationToken = default);
        Task<UpdateArticleDTO> UpdateArticleAsync(UpdateArticleDTO objDTO, CancellationToken cancellationToken = default);
        Task<DeleteArticleDTO> DeleteArticleAsync(DeleteArticleDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

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
    public interface IStockArticleService
    {
        public int RowCount { get; }
        Task<StockArticleDTO> FindStockArticleAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetStockArticlesAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedStockArticlesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, Expression<Func<StockArticle, bool>> predicate = null, string fields = null, string orderBy = null);
    }
}

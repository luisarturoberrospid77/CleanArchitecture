using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.Entities;
using CA.Domain.Entities.Base;

namespace CA.Domain.Interfaces.Services
{
    public interface IStockArticleService
    {
        public int RowCount { get; }
        Task<StockArticle> FindStockArticleAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetStockArticlesAsync(Expression<Func<StockArticle, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedStockArticlesAsync(int pageNumber, int pageSize, Expression<Func<StockArticle, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
    }
}

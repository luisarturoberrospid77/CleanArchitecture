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
    public interface IStockArticleRepository<TContext> : IBaseRepository<StockArticle, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<StockArticle>> GetStockArticlesAsync(CancellationToken cancellationToken = default);
        Task<StockArticle> GetStockArticleAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<StockArticle>> GetPagedStockArticlesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<StockArticle> SingleStockArticleAsync(Expression<Func<StockArticle, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<StockArticle>> FilterStockArticleAsync(Expression<Func<StockArticle, bool>> predicate, CancellationToken cancellationToken = default);
    }
}

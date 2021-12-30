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
  public class StockArticleRepository : BaseRepository<StockArticle, int, PatosaDbContext>,
                                        IStockArticleRepository<PatosaDbContext>
  {
    public StockArticleRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
    public async Task<IEnumerable<StockArticle>> FilterStockArticleAsync(Expression<Func<StockArticle, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterAsync(predicate, cancellationToken);
    public async Task<IEnumerable<StockArticle>> GetStockArticleAsync(CancellationToken cancellationToken = default) =>
      await AllAsync(cancellationToken);
    public async Task<StockArticle> GetStockArticleAsync(int id, CancellationToken cancellationToken = default) =>
      await GetByIdAsync(id, cancellationToken);
    public async Task<StockArticle> SingleStockArticleAsync(Expression<Func<StockArticle, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterSingleAsync(predicate, cancellationToken);
  }
}

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
  public class ArticleRepository : BaseRepository<Article, int, PatosaDbContext>,
                                   IArticleRepository<PatosaDbContext>
  {
    public ArticleRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
    public async Task AddArticleAsync(Article obj, CancellationToken cancellationToken = default) =>
      await AddAsync(obj, cancellationToken);
    public async Task AddRangeArticleAsync(IEnumerable<Article> obj, CancellationToken cancellationToken = default) =>
      await AddRangeAsync(obj, cancellationToken);
    public void DeleteArticle(Article obj) => Delete(obj);
    public async Task<IEnumerable<Article>> FilterArticleAsync(Expression<Func<Article, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterAsync(predicate, cancellationToken);
    public async Task<Article> GetArticleAsync(int id, CancellationToken cancellationToken = default) =>
      await GetByIdAsync(id, cancellationToken);
    public async Task<IEnumerable<Article>> GetArticlesAsync(CancellationToken cancellationToken = default) =>
      await AllAsync(cancellationToken);
    public async Task<Article> SingleArticleAsync(Expression<Func<Article, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterSingleAsync(predicate, cancellationToken);
    public void UpdateArticle(Article obj) => Update(obj);
  }
}

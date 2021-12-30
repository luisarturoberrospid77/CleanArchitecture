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
  public interface IArticleRepository<TContext> : IBaseRepository<Article, TContext>
    where TContext : DbContext, new()
  {
    Task<IEnumerable<Article>> GetArticlesAsync(CancellationToken cancellationToken = default);
    Task<Article> GetArticleAsync(int id, CancellationToken cancellationToken = default);
    Task<Article> SingleArticleAsync(Expression<Func<Article, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<Article>> FilterArticleAsync(Expression<Func<Article, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddArticleAsync(Article obj, CancellationToken cancellationToken = default);
    Task AddRangeArticleAsync(IEnumerable<Article> obj, CancellationToken cancellationToken = default);
    void UpdateArticle(Article obj);
    void DeleteArticle(Article obj);
  }
}

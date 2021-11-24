using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Core.Entities;

namespace CA.Core.Interfaces
{
  public interface IArticleRepository
  {
    Task<IEnumerable<Article>> GetArticlesAsync();
    Task<Article> GetArticleAsync(int id);
    Task AddArticle(Article obj);
  }
}


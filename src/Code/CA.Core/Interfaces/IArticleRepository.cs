using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Core.Entities;

namespace CA.Core.Interfaces
{
  public interface IArticleRepository
  {
    Task<IEnumerable<MtArticle>> GetArticlesAsync();
    Task<MtArticle> GetArticleAsync(int id);
  }
}


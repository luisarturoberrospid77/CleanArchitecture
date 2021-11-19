using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Core.Entities;
using CA.Core.Interfaces;
using CA.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure.Repositories
{
  public class ArticleRepository : IArticleRepository
  {
    private readonly PatosaDbContext _context;
    public ArticleRepository(PatosaDbContext PatosaDbContext) => _context = PatosaDbContext;

    public async Task<Article> GetArticleAsync(int id)
    {
      var _article = await _context.Articles.FirstOrDefaultAsync(x => x.SkuId == id);
      return _article;
    }

    public async Task<IEnumerable<Article>> GetArticlesAsync()
    {
      var _articles = await _context.Articles.ToListAsync();
      return _articles;
    }
  }
}


using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Domain.DTO;

namespace CA.Domain.Interfaces.Services
{
  public interface IStockArticleService
  {
    Task<StockArticleDTO> FindStockArticleAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<StockArticleDTO>> GetStockArticlesAsync(CancellationToken cancellationToken = default);
  }
}

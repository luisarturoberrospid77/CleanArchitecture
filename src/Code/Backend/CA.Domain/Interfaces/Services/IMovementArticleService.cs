using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Domain.DTO;

namespace CA.Domain.Interfaces.Services
{
  public interface IMovementArticleService
  {
    Task<MovementArticleDTO> FindMovementArticleAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<MovementArticleDTO>> GetMovementArticlesAsync(CancellationToken cancellationToken = default);
  }
}

using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Domain.DTO;

namespace CA.Domain.Interfaces.Services
{
  public interface IMenuService
  {
    Task<MenuDTO> FindMenuOptionAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<MenuDTO>> GetMenuOptionsAsync(CancellationToken cancellationToken = default);
  }
}

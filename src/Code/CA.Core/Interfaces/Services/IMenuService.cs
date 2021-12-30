using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Core.DTO;

namespace CA.Core.Interfaces.Services
{
  public interface IMenuService
  {
    Task<MenuDTO> FindMenuOptionAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<MenuDTO>> GetMenuOptions(CancellationToken cancellationToken = default);
  }
}

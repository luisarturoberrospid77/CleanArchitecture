using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Core.DTO;

namespace CA.Core.Interfaces.Services
{
  public interface ICategoryService
  {
    Task<CategoryDTO> FindCategoryAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CategoryDTO>> GetCategories(CancellationToken cancellationToken = default);
  }
}

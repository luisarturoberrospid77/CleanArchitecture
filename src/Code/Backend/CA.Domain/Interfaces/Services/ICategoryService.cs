using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Domain.DTO;

namespace CA.Domain.Interfaces.Services
{
  public interface ICategoryService
  {
    Task<CategoryDTO> FindCategoryAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CategoryDTO>> GetCategoriesAsync(CancellationToken cancellationToken = default);
  }
}

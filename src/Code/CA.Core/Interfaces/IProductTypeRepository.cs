using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Core.Entities;

namespace CA.Core.Interfaces
{
  public interface IProductTypeRepository
  {
    Task<IEnumerable<ProductType>> GetProductTypesAsync();
    Task<ProductType> GetProductTypeAsync(int id);
  }
}

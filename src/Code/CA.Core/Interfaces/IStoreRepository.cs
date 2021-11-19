using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Core.Entities;

namespace CA.Core.Interfaces
{
  public interface IStoreRepository
  {
    Task<IEnumerable<Store>> GetStoresAsync();
    Task<Store> GetStoreAsync(int id);
  }
}

using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Core.Entities;

namespace CA.Core.Interfaces
{
  public interface IStoreRepository
  {
    Task<IEnumerable<MtStore>> GetStoresAsync();
    Task<MtStore> GetStoreAsync(int id);
  }
}

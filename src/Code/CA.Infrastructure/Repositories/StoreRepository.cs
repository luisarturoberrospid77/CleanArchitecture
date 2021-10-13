using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Core.Entities;

namespace CA.Infrastructure.Repositories
{
  public class StoreRepository
  {
    public IEnumerable<mtStores> GetStores()
    {
      var _stores = Enumerable.Range(1, 50).Select(x => new mtStores
      {
        store_id = x,
        name = $"Store {x}",
        account_id = 1,
        address = $"Address for store {x}",
        creationdate = DateTime.UtcNow,
        updatedate = null
      }); ;
      return _stores;
    }
  }
}

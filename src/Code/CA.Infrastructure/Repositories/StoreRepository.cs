using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CA.Core.Entities;
using CA.Core.Interfaces;
using CA.Infrastructure.Data;

namespace CA.Infrastructure.Repositories
{
  public class StoreRepository : IStoreRepository
  {
    private readonly PatosaDbContext _patosaDbContext;

    public StoreRepository(PatosaDbContext patosaDbContext) => _patosaDbContext = patosaDbContext;

    public async Task<MtStore> GetStoreAsync(int id)
    {
      var _store = await _patosaDbContext.MtStores.FirstOrDefaultAsync(x => x.StoreId == id);
      return _store;
    }

    public async Task<IEnumerable<MtStore>> GetStoresAsync()
    {
      var _stores = await _patosaDbContext.MtStores.ToListAsync();
      return _stores;
    }
  }
}

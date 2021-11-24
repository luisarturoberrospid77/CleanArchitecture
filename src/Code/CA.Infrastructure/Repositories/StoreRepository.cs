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
    private readonly PatosaDbContext _context;

    public StoreRepository(PatosaDbContext patosaDbContext) => _context = patosaDbContext;

    public async Task AddStore(Store obj)
    {
      _context.Stores.Add(obj);
      await _context.SaveChangesAsync();
    }

    public async Task<Store> GetStoreAsync(int id)
    {
      var _store = await _context.Stores.FirstOrDefaultAsync(x => x.StoreId == id);
      return _store;
    }

    public async Task<IEnumerable<Store>> GetStoresAsync()
    {
      var _stores = await _context.Stores.ToListAsync();
      return _stores;
    }
  }
}

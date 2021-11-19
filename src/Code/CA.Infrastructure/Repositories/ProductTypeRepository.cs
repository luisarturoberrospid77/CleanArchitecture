using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Core.Entities;
using CA.Core.Interfaces;
using CA.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure.Repositories
{
  public class ProductTypeRepository : IProductTypeRepository
  {
    private readonly PatosaDbContext _context;
    public ProductTypeRepository(PatosaDbContext PatosaDbContext) => _context = PatosaDbContext;

    public async Task<ProductType> GetProductTypeAsync(int id)
    {
      var _productType = await _context.ProductTypes.FirstOrDefaultAsync(x => x.ProducttypeId == id);
      return _productType;
    }

    public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
    {
      var _productType = await _context.ProductTypes.ToListAsync();
      return _productType;
    }
  }
}

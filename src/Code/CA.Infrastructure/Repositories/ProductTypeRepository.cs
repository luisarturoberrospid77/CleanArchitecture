using System;
using System.Linq;
using System.Collections;
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

    public async Task<MtProductType> GetProductTypeAsync(int id)
    {
      var _productType = await _context.MtProductTypes.FirstOrDefaultAsync(x => x.ProducttypeId == id);
      return _productType;
    }

    public async Task<IEnumerable<MtProductType>> GetProductTypesAsync()
    {
      var _productType = await _context.MtProductTypes.ToListAsync();
      return _productType;
    }
  }
}

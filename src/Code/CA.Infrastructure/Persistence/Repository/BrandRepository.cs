using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Core.Entities;
using CA.Core.Interfaces.Base;
using CA.Core.Interfaces.Repository;

using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Repository.Base;

namespace CA.Infrastructure.Persistence.Repository
{
  public class BrandRepository : BaseRepository<Brand, int, PatosaDbContext>, IBrandRepository<PatosaDbContext>
  {
    public BrandRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
    public async Task AddBrandAsync(Brand obj, CancellationToken cancellationToken = default) =>
      await AddAsync(obj, cancellationToken);
    public void DeleteBrand(Brand obj) => DeleteBrand(obj);
    public async Task<IEnumerable<Brand>> FilterBrandAsync(Expression<Func<Brand, bool>> predicate, CancellationToken cancellationToken = default) => 
      await FilterAsync(predicate, cancellationToken);
    public async Task<Brand> GetBrandAsync(int id, CancellationToken cancellationToken = default) => 
      await GetByIdAsync(id, cancellationToken);
    public async Task<IEnumerable<Brand>> GetBrandsAsync(CancellationToken cancellationToken = default) => 
      await AllAsync(cancellationToken);
    public void UpdateBrand(Brand obj) => UpdateBrand(obj);
  }
}

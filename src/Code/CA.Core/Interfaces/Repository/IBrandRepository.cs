using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CA.Core.Entities;
using CA.Core.Interfaces.Base;

namespace CA.Core.Interfaces.Repository
{
  public interface IBrandRepository<TContext> : IBaseRepository<Brand, TContext> where TContext : DbContext, new()
  {
    Task<IEnumerable<Brand>> GetBrandsAsync(CancellationToken cancellationToken = default);
    Task<Brand> GetBrandAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Brand>> FilterBrandAsync(Expression<Func<Brand, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddBrandAsync(Brand obj, CancellationToken cancellationToken = default);
    void UpdateBrand(Brand obj);
    void DeleteBrand(Brand obj);
  }
}

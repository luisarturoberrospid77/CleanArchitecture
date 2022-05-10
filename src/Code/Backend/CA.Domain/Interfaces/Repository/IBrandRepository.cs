using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;

namespace CA.Domain.Interfaces.Repository
{
    public interface IBrandRepository<TContext> : IBaseRepository<Brand, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<Brand>> GetBrandsAsync(CancellationToken cancellationToken = default);
        Task<Brand> GetBrandAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Brand>> GetPagedBrandsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<Brand> SingleBrandAsync(Expression<Func<Brand, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<Brand>> FilterBrandAsync(Expression<Func<Brand, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddBrandAsync(Brand obj, CancellationToken cancellationToken = default);
        Task AddRangeBrandAsync(IEnumerable<Brand> obj, CancellationToken cancellationToken = default);
        void UpdateBrand(Brand obj);
        void DeleteBrand(Brand obj);
    }
}

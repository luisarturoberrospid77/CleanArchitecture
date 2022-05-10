using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Repository.Base;

namespace CA.Infrastructure.Common.Repositories
{
    public class BrandRepository : BaseRepository<Brand, int, PatosaDbContext>,
                                    IBrandRepository<PatosaDbContext>
    {
        public BrandRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
        public async Task AddBrandAsync(Brand obj, CancellationToken cancellationToken = default) =>
            await AddAsync(obj, cancellationToken);
        public async Task AddRangeBrandAsync(IEnumerable<Brand> obj, CancellationToken cancellationToken = default) =>
            await AddRangeAsync(obj, cancellationToken);
        public void DeleteBrand(Brand obj) => Delete(obj);
        public async Task<IEnumerable<Brand>> FilterBrandAsync(Expression<Func<Brand, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterAsync(predicate, cancellationToken);
        public async Task<Brand> GetBrandAsync(int id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken);
        public async Task<IEnumerable<Brand>> GetBrandsAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
        public async Task<IEnumerable<Brand>> GetPagedBrandsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default) =>
            await GetPagedAsync(pageNumber, pageSize, cancellationToken);
        public async Task<Brand> SingleBrandAsync(Expression<Func<Brand, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterSingleAsync(predicate, cancellationToken);
        public void UpdateBrand(Brand obj) => Update(obj);
    }
}

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
    public class SupplierRepository : BaseRepository<Supplier, int, PatosaDbContext>,
                                        ISupplierRepository<PatosaDbContext>
    {
        public SupplierRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
        public async Task AddSupplierAsync(Supplier obj, CancellationToken cancellationToken = default) =>
            await AddAsync(obj, cancellationToken);
        public async Task AddRangeSupplierAsync(IEnumerable<Supplier> obj, CancellationToken cancellationToken = default) =>
            await AddRangeAsync(obj, cancellationToken);
        public void DeleteSupplier(Supplier obj) => Delete(obj);
        public async Task<IEnumerable<Supplier>> FilterSupplierAsync(Expression<Func<Supplier, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterAsync(predicate, cancellationToken);
        public async Task<IEnumerable<Supplier>> GetSuppliersAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
        public async Task<Supplier> GetSupplierAsync(int id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken);
        public async Task<Supplier> SingleSupplierAsync(Expression<Func<Supplier, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterSingleAsync(predicate, cancellationToken);
        public void UpdateSupplier(Supplier obj) => Update(obj);
        public async Task<IEnumerable<Supplier>> GetPagedSuppliersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default) =>
            await GetPagedAsync(pageNumber, pageSize, cancellationToken);
    }
}

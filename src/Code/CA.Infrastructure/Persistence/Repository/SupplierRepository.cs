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
  public class SupplierRepository : BaseRepository<Supplier, int, PatosaDbContext>, ISupplierRepository<PatosaDbContext>
  {
    public SupplierRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
    public async Task AddSupplierAsync(Supplier obj, CancellationToken cancellationToken = default) =>
      await AddAsync(obj, cancellationToken);
    public void DeleteSupplier(Supplier obj) => DeleteSupplier(obj);
    public async Task<IEnumerable<Supplier>> FilterSupplierAsync(Expression<Func<Supplier, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterAsync(predicate, cancellationToken);
    public async Task<IEnumerable<Supplier>> GetSupplierAsync(CancellationToken cancellationToken = default) => 
      await AllAsync(cancellationToken);
    public async Task<Supplier> GetSupplierAsync(int id, CancellationToken cancellationToken = default) => 
      await GetByIdAsync(id, cancellationToken);
    public void UpdateSupplier(Supplier obj) => UpdateSupplier(obj);
  }
}

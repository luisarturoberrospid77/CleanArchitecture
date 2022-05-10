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
    public interface ISupplierRepository<TContext> : IBaseRepository<Supplier, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<Supplier>> GetSuppliersAsync(CancellationToken cancellationToken = default);
        Task<Supplier> GetSupplierAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Supplier>> GetPagedSuppliersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<Supplier> SingleSupplierAsync(Expression<Func<Supplier, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<Supplier>> FilterSupplierAsync(Expression<Func<Supplier, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddSupplierAsync(Supplier obj, CancellationToken cancellationToken = default);
        Task AddRangeSupplierAsync(IEnumerable<Supplier> obj, CancellationToken cancellationToken = default);
        void UpdateSupplier(Supplier obj);
        void DeleteSupplier(Supplier obj);
    }
}

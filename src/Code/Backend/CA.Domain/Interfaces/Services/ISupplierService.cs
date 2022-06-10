using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Entities.Base;

namespace CA.Domain.Interfaces.Services
{
    public interface ISupplierService
    {
        public int RowCount { get; }
        Task<Supplier> FindSupplierAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetSuppliersAsync(Expression<Func<Supplier, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedSuppliersAsync(int pageNumber, int pageSize, Expression<Func<Supplier, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<Supplier> InsertSupplierAsync(CreateSupplierDTO objDTO, CancellationToken cancellationToken = default);
        Task<Supplier> UpdateSupplierAsync(UpdateSupplierDTO objDTO, CancellationToken cancellationToken = default);
        Task<Supplier> DeleteSupplierAsync(DeleteSupplierDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

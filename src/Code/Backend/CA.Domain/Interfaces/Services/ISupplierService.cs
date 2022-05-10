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
        Task<SupplierDTO> FindSupplierAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetSuppliersAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedSuppliersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, Expression<Func<Supplier, bool>> predicate = null, string fields = null, string orderBy = null);
        Task<CreateSupplierDTO> InsertSupplierAsync(CreateSupplierDTO objDTO, CancellationToken cancellationToken = default);
        Task<UpdateSupplierDTO> UpdateSupplierAsync(UpdateSupplierDTO objDTO, CancellationToken cancellationToken = default);
        Task<DeleteSupplierDTO> DeleteSupplierAsync(DeleteSupplierDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

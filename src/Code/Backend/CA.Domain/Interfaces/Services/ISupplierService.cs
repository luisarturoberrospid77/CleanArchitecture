using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Domain.DTO;

namespace CA.Domain.Interfaces.Services
{
  public interface ISupplierService
  {
    Task<SupplierDTO> FindSupplierAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<SupplierDTO>> GetSuppliersAsync(CancellationToken cancellationToken = default);
    Task<CreateSupplierDTO> InsertSupplierAsync(CreateSupplierDTO objDTO, CancellationToken cancellationToken = default);
    Task<UpdateSupplierDTO> UpdateSupplierAsync(UpdateSupplierDTO objDTO, CancellationToken cancellationToken = default);
    Task<DeleteSupplierDTO> DeleteSupplierAsync(DeleteSupplierDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
  }
}

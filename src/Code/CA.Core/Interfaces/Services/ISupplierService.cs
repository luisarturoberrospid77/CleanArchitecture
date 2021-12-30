using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Core.DTO;

namespace CA.Core.Interfaces.Services
{
  public interface ISupplierService
  {
    Task<SupplierDTO> FindStoreAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<SupplierDTO>> GetStores(CancellationToken cancellationToken = default);
    Task<CreateSupplierDTO> InsertStoreAsync(CreateSupplierDTO objDTO, CancellationToken cancellationToken = default);
    Task<UpdateSupplierDTO> UpdateSupplierAsync(UpdateSupplierDTO objDTO, CancellationToken cancellationToken = default);
    Task<DeleteSupplierDTO> DeleteSupplierAsync(DeleteSupplierDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
  }
}

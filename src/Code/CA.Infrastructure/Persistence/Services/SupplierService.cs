using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using CA.Core.DTO;
using CA.Core.Entities;
using CA.Core.Interfaces.Base;
using CA.Core.Interfaces.Services;
using CA.Core.Interfaces.Repository;

using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Persistence.Services
{
  public class SupplierService : CRUDService<SupplierDTO, CreateSupplierDTO, UpdateSupplierDTO, DeleteSupplierDTO, int,
                                               Supplier, ISupplierRepository<PatosaDbContext>, PatosaDbContext>, ISupplierService
  {
    public SupplierService(IMapper mapper, IUnitOfWork<PatosaDbContext> unitOfWork, ISupplierRepository<PatosaDbContext> supplierRepository) : 
      base(supplierRepository, unitOfWork, mapper) { }
    public async Task<SupplierDTO> FindStoreAsync(int id, CancellationToken cancellationToken = default) => 
      await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<SupplierDTO>> GetStores(CancellationToken cancellationToken = default) => 
      await GetAll(cancellationToken);
    public async Task<CreateSupplierDTO> InsertStoreAsync(CreateSupplierDTO objDTO, CancellationToken cancellationToken = default) => 
      await InsertAsync(objDTO, cancellationToken);
    public async Task<UpdateSupplierDTO> UpdateSupplierAsync(UpdateSupplierDTO objDTO, CancellationToken cancellationToken = default) => 
      await UpdateAsync(objDTO, cancellationToken);
    public async Task<DeleteSupplierDTO> DeleteSupplierAsync(DeleteSupplierDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default) =>
      await DeleteAsync(objDTO, autoSave, cancellationToken);
  }
}

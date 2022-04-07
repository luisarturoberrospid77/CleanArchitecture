using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.DTO.Base;
using CA.Domain.Entities;
using CA.Domain.Exceptions;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Repository;
using CA.Domain.Interfaces.Services;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
  public class SupplierService : CRUDService<SupplierDTO, CommandDTO, int,
                                               Supplier, ISupplierRepository<PatosaDbContext>,
                                               PatosaDbContext>, ISupplierService
  {
    public SupplierService(IMapper mapper,
                           IUnitOfWork<PatosaDbContext> unitOfWork,
                           ISupplierRepository<PatosaDbContext> supplierRepository) : base(mapper, supplierRepository, unitOfWork) { }
    public async Task<SupplierDTO> FindSupplierAsync(int id, CancellationToken cancellationToken = default) =>
      await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<SupplierDTO>> GetSuppliersAsync(CancellationToken cancellationToken = default) =>
      await GetAllAsync(cancellationToken);
    public async Task<CreateSupplierDTO> InsertSupplierAsync(CreateSupplierDTO objDTO, CancellationToken cancellationToken = default)
    {
      var ifExists = await FilterAsync(u => u.Name == objDTO.Name && u.IsDeleted == false);

      if (ifExists.Count() > 0)
        throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.Name);
      else
        return Mapper.Map<CreateSupplierDTO>(await InsertAsync(objDTO, cancellationToken));
    }
    public async Task<UpdateSupplierDTO> UpdateSupplierAsync(UpdateSupplierDTO objDTO, CancellationToken cancellationToken = default)
    {
      var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

      if (ifExists == null)
        throw new EntityNotFoundException(objDTO.Id.ToString());
      else
        return Mapper.Map<UpdateSupplierDTO>(await UpdateAsync(objDTO, cancellationToken));
    }
    public async Task<DeleteSupplierDTO> DeleteSupplierAsync(DeleteSupplierDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
    {
      var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

      if (ifExists == null | ifExists.Count() == 0)
        throw new EntityNotFoundException(objDTO.Id.ToString());
      else
        return Mapper.Map<DeleteSupplierDTO>(await DeleteAsync(objDTO, autoSave, cancellationToken));
    }
  }
}

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
  public class StoreService : CRUDService<StoreDTO, CreateStoreDTO, UpdateStoreDTO, DeleteStoreDTO, int,
                                          Store, IStoreRepository<PatosaDbContext>, PatosaDbContext>, IStoreService
  {
    public StoreService(IMapper mapper, IUnitOfWork<PatosaDbContext> unitOfWork, IStoreRepository<PatosaDbContext> storeRepository) : 
      base(storeRepository, unitOfWork, mapper) { }
    public async Task<StoreDTO> FindStoreAsync(int id, CancellationToken cancellationToken = default) => 
      await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<StoreDTO>> GetStores(CancellationToken cancellationToken = default) => 
      await GetAll(cancellationToken);
    public async Task<CreateStoreDTO> InsertStoreAsync(CreateStoreDTO objDTO, CancellationToken cancellationToken = default) => 
      await InsertAsync(objDTO, cancellationToken);
    public async Task<UpdateStoreDTO> UpdateStoreAsync(UpdateStoreDTO objDTO, CancellationToken cancellationToken = default) => 
      await UpdateAsync(objDTO, cancellationToken);
    public async Task<DeleteStoreDTO> DeleteStoreAsync(DeleteStoreDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default) =>
      await DeleteAsync(objDTO, autoSave, cancellationToken);
  }
}

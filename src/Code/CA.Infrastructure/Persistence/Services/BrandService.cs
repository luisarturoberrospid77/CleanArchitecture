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
  public class BrandService : CRUDService<BrandDTO, CreateBrandDTO, UpdateBrandDTO, DeleteBrandDTO, int,
                                          Brand, IBrandRepository<PatosaDbContext>, PatosaDbContext>, IBrandService
  {
    public BrandService(IMapper mapper, IUnitOfWork<PatosaDbContext> unitOfWork, IBrandRepository<PatosaDbContext> brandRepository) : 
      base(brandRepository, unitOfWork, mapper) { }
    public async Task<BrandDTO> FindBrandAsync(int id, CancellationToken cancellationToken = default) => 
      await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<BrandDTO>> GetBrands(CancellationToken cancellationToken = default) => 
      await GetAll(cancellationToken);
    public async Task<CreateBrandDTO> InsertBrandAsync(CreateBrandDTO objDTO, CancellationToken cancellationToken = default) => 
      await InsertAsync(objDTO, cancellationToken);
    public async Task<UpdateBrandDTO> UpdateBrandAsync(UpdateBrandDTO objDTO, CancellationToken cancellationToken = default) =>
      await UpdateAsync(objDTO, cancellationToken);
    public async Task<DeleteBrandDTO> DeleteBrandAsync(DeleteBrandDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default) =>
      await DeleteAsync(objDTO, autoSave, cancellationToken);
  }
}

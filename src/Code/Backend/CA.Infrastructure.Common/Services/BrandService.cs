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
  public class BrandService : CRUDService<BrandDTO, CommandDTO, int,
                                          Brand, IBrandRepository<PatosaDbContext>,
                                          PatosaDbContext>, IBrandService
  {
    public BrandService(IMapper mapper,
                        IUnitOfWork<PatosaDbContext> unitOfWork,
                        IBrandRepository<PatosaDbContext> brandRepository) : base(mapper, brandRepository, unitOfWork) { }
    public async Task<BrandDTO> FindBrandAsync(int id, CancellationToken cancellationToken = default) =>
      await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<BrandDTO>> GetBrandsAsync(CancellationToken cancellationToken = default) =>
      await GetAllAsync(cancellationToken);
    public async Task<CreateBrandDTO> InsertBrandAsync(CreateBrandDTO objDTO, CancellationToken cancellationToken = default)
    {
      var ifExists = await FilterAsync(u => u.Name == objDTO.Name && u.IsDeleted == false);

      if (ifExists.Count() > 0)
        throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.Name);
      else
        return Mapper.Map<CreateBrandDTO>(await InsertAsync(objDTO, cancellationToken));
    }
    public async Task<UpdateBrandDTO> UpdateBrandAsync(UpdateBrandDTO objDTO, CancellationToken cancellationToken = default)
    {
      var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

      if (ifExists == null)
        throw new EntityNotFoundException(objDTO.Id.ToString());
      else
        return Mapper.Map<UpdateBrandDTO>(await UpdateAsync(objDTO, cancellationToken));
    }
    public async Task<DeleteBrandDTO> DeleteBrandAsync(DeleteBrandDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
    {
      var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

      if (ifExists == null | ifExists.Count() == 0)
        throw new EntityNotFoundException(objDTO.Id.ToString());
      else
        return Mapper.Map<DeleteBrandDTO>(await DeleteAsync(objDTO, autoSave, cancellationToken));
    }
  }
}

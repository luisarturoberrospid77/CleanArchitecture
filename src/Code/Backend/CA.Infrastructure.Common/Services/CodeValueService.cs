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
  public class CodeValueService : CRUDService<CodeValueDTO, CommandDTO, int,
                                              CodeValue, ICodeValueRepository<PatosaDbContext>,
                                              PatosaDbContext>, ICodeValueService
  {
    public CodeValueService(IMapper mapper,
                            IUnitOfWork<PatosaDbContext> unitOfWork,
                            ICodeValueRepository<PatosaDbContext> codeValueRepository) : base(mapper, codeValueRepository, unitOfWork) { }
    public async Task<CodeValueDTO> FindCodeValueAsync(int id, CancellationToken cancellationToken = default) =>
      await GetSingleAsync(u => u.Id == id & u.IsDeleted == false, cancellationToken);
    public async Task<IEnumerable<CodeValueDTO>> GetCodeValuesAsync(CancellationToken cancellationToken = default) =>
      await GetAllAsync(cancellationToken);
    public async Task<CreateCodeValueDTO> InsertCodeValueAsync(CreateCodeValueDTO objDTO, CancellationToken cancellationToken = default)
    {
      var ifExists = await FilterAsync(u => u.Description == objDTO.Description && u.IsDeleted == false, cancellationToken);

      if (ifExists.Count() > 0)
        throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.Description);
      else
        return Mapper.Map<CreateCodeValueDTO>(await InsertAsync(objDTO, cancellationToken));
    }
    public async Task<UpdateCodeValueDTO> UpdateCodeValueAsync(UpdateCodeValueDTO objDTO, CancellationToken cancellationToken = default)
    {
      var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false, cancellationToken);

      if (ifExists == null)
        throw new EntityNotFoundException(objDTO.Id.ToString());
      else
        return Mapper.Map<UpdateCodeValueDTO>(await UpdateAsync(objDTO, cancellationToken));
    }
    public async Task<DeleteCodeValueDTO> DeleteCodeValueAsync(DeleteCodeValueDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
    {
      var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false, cancellationToken);

      if (ifExists == null | ifExists.Count() == 0)
        throw new EntityNotFoundException(objDTO.Id.ToString());
      else
        return Mapper.Map<DeleteCodeValueDTO>(await DeleteAsync(objDTO, autoSave, cancellationToken));
    }
  }
}

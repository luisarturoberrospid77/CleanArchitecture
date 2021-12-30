using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Domain.DTO;

namespace CA.Domain.Interfaces.Services
{
  public interface ICodeValueService
  {
    Task<CodeValueDTO> FindCodeValueAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CodeValueDTO>> GetCodeValuesAsync(CancellationToken cancellationToken = default);
    Task<CreateCodeValueDTO> InsertCodeValueAsync(CreateCodeValueDTO objDTO, CancellationToken cancellationToken = default);
    Task<UpdateCodeValueDTO> UpdateCodeValueAsync(UpdateCodeValueDTO objDTO, CancellationToken cancellationToken = default);
    Task<DeleteCodeValueDTO> DeleteCodeValueAsync(DeleteCodeValueDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
  }
}

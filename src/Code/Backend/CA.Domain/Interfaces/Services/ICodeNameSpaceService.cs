using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Domain.DTO;

namespace CA.Domain.Interfaces.Services
{
  public interface ICodeNameSpaceService
  {
    Task<CodeNameSpaceDTO> FindCodeNameSpaceAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CodeNameSpaceDTO>> GetCodeNameSpacesAsync(CancellationToken cancellationToken = default);
    Task<CreateCodeNameSpaceDTO> InsertCodeNameSpaceAsync(CreateCodeNameSpaceDTO objDTO, CancellationToken cancellationToken = default);
    Task<UpdateCodeNameSpaceDTO> UpdateCodeNameSpaceAsync(UpdateCodeNameSpaceDTO objDTO, CancellationToken cancellationToken = default);
    Task<DeleteCodeNameSpaceDTO> DeleteCodeNameSpaceAsync(DeleteCodeNameSpaceDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
  }
}

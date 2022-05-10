using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class DeleteCodeNameSpaceHandler : IRequestHandler<DeleteCodeNameSpaceDTO, ApiResponse<DeleteCodeNameSpaceDTO>>
    {
        private readonly ICodeNameSpaceService _codeNameSpaceService;
        public DeleteCodeNameSpaceHandler(ICodeNameSpaceService codeNameSpaceService) => _codeNameSpaceService = codeNameSpaceService;
        public async Task<ApiResponse<DeleteCodeNameSpaceDTO>> Handle(DeleteCodeNameSpaceDTO request, CancellationToken cancellationToken)
        {
            var entity = await _codeNameSpaceService.DeleteCodeNameSpaceAsync(request, request.AutoSave, cancellationToken);
            return new ApiResponse<DeleteCodeNameSpaceDTO>(entity, $"The code name space with Id {entity.Id} was successfully deleted.");
        }
    }
}

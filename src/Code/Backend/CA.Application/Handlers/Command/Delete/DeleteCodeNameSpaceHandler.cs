using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class DeleteCodeNameSpaceHandler : IRequestHandler<DeleteCodeNameSpaceDTO, ApiResponse<DeleteCodeNameSpaceDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICodeNameSpaceService _codeNameSpaceService;
        public DeleteCodeNameSpaceHandler(ICodeNameSpaceService codeNameSpaceService, IMapper mapper) =>
            (_codeNameSpaceService, _mapper) = (codeNameSpaceService, mapper);
        public async Task<ApiResponse<DeleteCodeNameSpaceDTO>> Handle(DeleteCodeNameSpaceDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DeleteCodeNameSpaceDTO>(await _codeNameSpaceService.DeleteCodeNameSpaceAsync(request, request.AutoSave, cancellationToken));
            return new ApiResponse<DeleteCodeNameSpaceDTO>(entity, $"The code namespace with Id {entity.Id} was successfully deleted.");
        }
    }
}

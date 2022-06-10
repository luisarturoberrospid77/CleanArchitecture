using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class UpdateCodeNameSpaceHandler : IRequestHandler<UpdateCodeNameSpaceDTO, ApiResponse<UpdateCodeNameSpaceDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICodeNameSpaceService _codeNameSpaceService;
        public UpdateCodeNameSpaceHandler(ICodeNameSpaceService codeNameSpaceService, IMapper mapper) =>
            (_codeNameSpaceService, _mapper) = (codeNameSpaceService, mapper);
        public async Task<ApiResponse<UpdateCodeNameSpaceDTO>> Handle(UpdateCodeNameSpaceDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UpdateCodeNameSpaceDTO>(await _codeNameSpaceService.UpdateCodeNameSpaceAsync(request, cancellationToken));
            return new ApiResponse<UpdateCodeNameSpaceDTO>(entity, $"The code name space with Id {entity.Id} was successfully updated.");
        }
    }
}

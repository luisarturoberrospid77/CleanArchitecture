using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class CreateCodeNameSpaceHandler : IRequestHandler<CreateCodeNameSpaceDTO, ApiResponse<CreateCodeNameSpaceDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICodeNameSpaceService _codeNameSpaceService;
        public CreateCodeNameSpaceHandler(ICodeNameSpaceService codeNameSpaceService, IMapper mapper) =>
            (_codeNameSpaceService, _mapper) = (codeNameSpaceService, mapper);
        public async Task<ApiResponse<CreateCodeNameSpaceDTO>> Handle(CreateCodeNameSpaceDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateCodeNameSpaceDTO>(await _codeNameSpaceService.InsertCodeNameSpaceAsync(request, cancellationToken));
            return new ApiResponse<CreateCodeNameSpaceDTO>(entity, $"The code namespace with name '{entity.Name}' was created successfully.");
        }
    }
}

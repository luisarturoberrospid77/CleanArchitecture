using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetCodeNameSpaceHandler : IRequestHandler<GetCodeNameSpaceQuery, CodeNameSpaceDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICodeNameSpaceService _codeNameSpaceService;
        public GetCodeNameSpaceHandler(ICodeNameSpaceService codeNameSpaceService, IMapper mapper) =>
            (_codeNameSpaceService, _mapper) = (codeNameSpaceService, mapper);
        public async Task<CodeNameSpaceDTO> Handle(GetCodeNameSpaceQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<CodeNameSpaceDTO>(await _codeNameSpaceService.FindCodeNameSpaceAsync(request.Id, cancellationToken));
    }
}

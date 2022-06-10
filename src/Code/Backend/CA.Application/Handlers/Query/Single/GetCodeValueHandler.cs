using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetCodeValueHandler : IRequestHandler<GetCodeValueQuery, CodeValueDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICodeValueService _codeValueService;
        public GetCodeValueHandler(ICodeValueService codeValueService, IMapper mapper) =>
            (_codeValueService, _mapper) = (codeValueService, mapper);
        public async Task<CodeValueDTO> Handle(GetCodeValueQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<CodeValueDTO>(await _codeValueService.FindCodeValueAsync(request.Id, cancellationToken));
    }
}

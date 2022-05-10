using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetCodeValueHandler : IRequestHandler<GetCodeValueQuery, CodeValueDTO>
    {
        private readonly ICodeValueService _codeValueService;
        public GetCodeValueHandler(ICodeValueService codeValueService) => _codeValueService = codeValueService;
        public async Task<CodeValueDTO> Handle(GetCodeValueQuery request, CancellationToken cancellationToken) =>
            await _codeValueService.FindCodeValueAsync(request.Id, cancellationToken);
    }
}

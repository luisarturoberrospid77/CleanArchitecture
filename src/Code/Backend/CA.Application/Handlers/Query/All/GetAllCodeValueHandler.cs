using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllCodeValueHandler : IRequestHandler<GetAllCodeValueQuery, IEnumerable<CodeValueDTO>>
  {
    private readonly ICodeValueService _codeValueService;
    public GetAllCodeValueHandler(ICodeValueService codeValueService) => _codeValueService = codeValueService;
    public async Task<IEnumerable<CodeValueDTO>> Handle(GetAllCodeValueQuery request, CancellationToken cancellationToken) =>
      await _codeValueService.GetCodeValuesAsync(cancellationToken);
  }
}

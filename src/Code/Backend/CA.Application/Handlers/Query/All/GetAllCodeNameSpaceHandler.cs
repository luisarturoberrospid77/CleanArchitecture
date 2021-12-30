using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllCodeNameSpaceHandler : IRequestHandler<GetAllCodeNameSpaceQuery, IEnumerable<CodeNameSpaceDTO>>
  {
    private readonly ICodeNameSpaceService _codeNameSpaceService;
    public GetAllCodeNameSpaceHandler(ICodeNameSpaceService codeNameSpaceService) => _codeNameSpaceService = codeNameSpaceService;
    public async Task<IEnumerable<CodeNameSpaceDTO>> Handle(GetAllCodeNameSpaceQuery request, CancellationToken cancellationToken) =>
      await _codeNameSpaceService.GetCodeNameSpacesAsync(cancellationToken);
  }
}

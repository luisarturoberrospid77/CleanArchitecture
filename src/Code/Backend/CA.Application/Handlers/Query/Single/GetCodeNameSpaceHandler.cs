using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetCodeNameSpaceHandler : IRequestHandler<GetCodeNameSpaceQuery, CodeNameSpaceDTO>
  {
    private readonly ICodeNameSpaceService _codeNameSpaceService;
    public GetCodeNameSpaceHandler(ICodeNameSpaceService CodeNameSpaceService) => _codeNameSpaceService = CodeNameSpaceService;
    public async Task<CodeNameSpaceDTO> Handle(GetCodeNameSpaceQuery request, CancellationToken cancellationToken) =>
      await _codeNameSpaceService.FindCodeNameSpaceAsync(request.Id, cancellationToken);
  }
}

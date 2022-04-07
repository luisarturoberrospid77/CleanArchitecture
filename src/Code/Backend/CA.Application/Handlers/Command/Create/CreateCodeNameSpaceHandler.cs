using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
  public class CreateCodeNameSpaceHandler : IRequestHandler<CreateCodeNameSpaceDTO, ApiResponse<CreateCodeNameSpaceDTO>>
  {
    private readonly ICodeNameSpaceService _codeNameSpaceService;
    public CreateCodeNameSpaceHandler(ICodeNameSpaceService codeNameSpaceService) => _codeNameSpaceService = codeNameSpaceService;
    public async Task<ApiResponse<CreateCodeNameSpaceDTO>> Handle(CreateCodeNameSpaceDTO request, CancellationToken cancellationToken)
    {
      var entity = await _codeNameSpaceService.InsertCodeNameSpaceAsync(request, cancellationToken);
      return new ApiResponse<CreateCodeNameSpaceDTO>(entity, $"The code name space with name '{entity.Name}' was created successfully.");
    }
  }
}

using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
  public class CreateCodeValueHandler : IRequestHandler<CreateCodeValueDTO, ApiResponse<CreateCodeValueDTO>>
  {
    private readonly ICodeValueService _codeValueService;
    public CreateCodeValueHandler(ICodeValueService codeValueService) => _codeValueService = codeValueService;
    public async Task<ApiResponse<CreateCodeValueDTO>> Handle(CreateCodeValueDTO request, CancellationToken cancellationToken)
    {
      var entity = await _codeValueService.InsertCodeValueAsync(request, cancellationToken);
      return new ApiResponse<CreateCodeValueDTO>(entity, $"The code value with name '{entity.Description}' was created successfully.");
    }
  }
}

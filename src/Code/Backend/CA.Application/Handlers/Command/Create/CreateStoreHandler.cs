using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
  public class CreateStoreHandler : IRequestHandler<CreateStoreDTO, ApiResponse<CreateStoreDTO>>
  {
    private readonly IStoreService _storeService;
    public CreateStoreHandler(IStoreService storeService) => _storeService = storeService;
    public async Task<ApiResponse<CreateStoreDTO>> Handle(CreateStoreDTO request, CancellationToken cancellationToken)
    {
      var entity = await _storeService.InsertStoreAsync(request, cancellationToken);
      return new ApiResponse<CreateStoreDTO>(entity, $"The branch with name '{entity.Name}' was created successfully.");
    }
  }
}

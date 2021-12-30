using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
  public class DeleteStoreHandler : IRequestHandler<DeleteStoreDTO, ApiResponse<DeleteStoreDTO>>
  {
    private readonly IStoreService _storeService;
    public DeleteStoreHandler(IStoreService storeService) => _storeService = storeService;
    public async Task<ApiResponse<DeleteStoreDTO>> Handle(DeleteStoreDTO request, CancellationToken cancellationToken)
    {
      var entity = await _storeService.DeleteStoreAsync(request, request.AutoSave, cancellationToken);
      return new ApiResponse<DeleteStoreDTO>(entity, $"The branch with Id {entity.Id} was successfully deleted.");
    }
  }
}

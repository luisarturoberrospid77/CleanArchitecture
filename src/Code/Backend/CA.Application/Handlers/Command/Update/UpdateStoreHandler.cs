using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class UpdateStoreHandler : IRequestHandler<UpdateStoreDTO, ApiResponse<UpdateStoreDTO>>
    {
        private readonly IStoreService _storeService;
        public UpdateStoreHandler(IStoreService storeService) => _storeService = storeService;
        public async Task<ApiResponse<UpdateStoreDTO>> Handle(UpdateStoreDTO request, CancellationToken cancellationToken)
        {
            var entity = await _storeService.UpdateStoreAsync(request, cancellationToken);
            return new ApiResponse<UpdateStoreDTO>(entity, $"The branch with Id {entity.Id} was successfully updated.");
        }
    }
}

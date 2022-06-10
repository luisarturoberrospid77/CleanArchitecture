using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class UpdateStoreHandler : IRequestHandler<UpdateStoreDTO, ApiResponse<UpdateStoreDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IStoreService _storeService;
        public UpdateStoreHandler(IStoreService storeService, IMapper mapper) =>
            (_storeService, _mapper) = (storeService, mapper);
        public async Task<ApiResponse<UpdateStoreDTO>> Handle(UpdateStoreDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UpdateStoreDTO>(await _storeService.UpdateStoreAsync(request, cancellationToken));
            return new ApiResponse<UpdateStoreDTO>(entity, $"The store with Id {entity.Id} was successfully updated.");
        }
    }
}

using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class CreateStoreHandler : IRequestHandler<CreateStoreDTO, ApiResponse<CreateStoreDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IStoreService _storeService;
        public CreateStoreHandler(IStoreService storeService, IMapper mapper) =>
            (_storeService, _mapper) = (storeService, mapper);
        public async Task<ApiResponse<CreateStoreDTO>> Handle(CreateStoreDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateStoreDTO>(await _storeService.InsertStoreAsync(request, cancellationToken));
            return new ApiResponse<CreateStoreDTO>(entity, $"The store with name '{entity.Name}' was created successfully.");
        }
    }
}

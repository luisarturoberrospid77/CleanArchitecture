using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class DeleteStoreHandler : IRequestHandler<DeleteStoreDTO, ApiResponse<DeleteStoreDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IStoreService _storeService;
        public DeleteStoreHandler(IStoreService storeService, IMapper mapper) =>
            (_storeService, _mapper) = (storeService, mapper);
        public async Task<ApiResponse<DeleteStoreDTO>> Handle(DeleteStoreDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DeleteStoreDTO>(await _storeService.DeleteStoreAsync(request, request.AutoSave, cancellationToken));
            return new ApiResponse<DeleteStoreDTO>(entity, $"The store with Id {entity.Id} was successfully deleted.");
        }
    }
}

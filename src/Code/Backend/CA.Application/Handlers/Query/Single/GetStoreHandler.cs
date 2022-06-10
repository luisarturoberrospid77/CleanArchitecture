using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetStoreHandler : IRequestHandler<GetStoreQuery, StoreDTO>
    {
        private readonly IMapper _mapper;
        private readonly IStoreService _storeService;
        public GetStoreHandler(IStoreService storeService, IMapper mapper) =>
            (_storeService, _mapper) = (storeService, mapper);
        public async Task<StoreDTO> Handle(GetStoreQuery request, CancellationToken cancellationToken) => 
            _mapper.Map<StoreDTO>(await _storeService.FindStoreAsync(request.Id, cancellationToken));
    }
}

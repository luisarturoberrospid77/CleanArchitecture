using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllStoreHandler : IRequestHandler<GetAllStoreQuery, IEnumerable<StoreDTO>>
  {
    private readonly IStoreService _storeService;
    public GetAllStoreHandler(IStoreService storeService) => _storeService = storeService;
    public async Task<IEnumerable<StoreDTO>> Handle(GetAllStoreQuery request, CancellationToken cancellationToken) =>
      await _storeService.GetStoresAsync(cancellationToken);
  }
}

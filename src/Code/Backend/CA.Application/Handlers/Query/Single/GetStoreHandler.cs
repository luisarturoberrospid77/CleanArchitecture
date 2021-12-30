using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetStoreHandler : IRequestHandler<GetStoreQuery, StoreDTO>
  {
    private readonly IStoreService _storeService;
    public GetStoreHandler(IStoreService storeService) => _storeService = storeService;
    public async Task<StoreDTO> Handle(GetStoreQuery request, CancellationToken cancellationToken) =>
      await _storeService.FindStoreAsync(request.Id, cancellationToken);
  }
}

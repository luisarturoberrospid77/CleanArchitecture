using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetBrandHandler : IRequestHandler<GetBrandQuery, BrandDTO>
  {
    private readonly IBrandService _brandService;
    public GetBrandHandler(IBrandService brandService) => _brandService = brandService;
    public async Task<BrandDTO> Handle(GetBrandQuery request, CancellationToken cancellationToken) =>
      await _brandService.FindBrandAsync(request.Id, cancellationToken);
  }
}

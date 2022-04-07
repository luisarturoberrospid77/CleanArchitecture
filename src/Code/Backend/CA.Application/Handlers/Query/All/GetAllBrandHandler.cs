using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllBrandHandler : IRequestHandler<GetAllBrandQuery, IEnumerable<BrandDTO>>
  {
    private readonly IBrandService _brandService;
    public GetAllBrandHandler(IBrandService brandService) => _brandService = brandService;
    public async Task<IEnumerable<BrandDTO>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken) =>
      await _brandService.GetBrandsAsync(cancellationToken);
  }
}

using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetCountryDetailHandler : IRequestHandler<GetCountryDetailQuery, CountryDetailDTO>
  {
    private readonly ICountryDetailService _countryDetailService;
    public GetCountryDetailHandler(ICountryDetailService countryDetailService) => _countryDetailService = countryDetailService;
    public async Task<CountryDetailDTO> Handle(GetCountryDetailQuery request, CancellationToken cancellationToken) =>
      await _countryDetailService.FindCountryDetailAsync(request.Id, cancellationToken);
  }
}

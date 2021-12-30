using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllCountryDetailHandler : IRequestHandler<GetAllCountryDetailQuery, IEnumerable<CountryDetailDTO>>
  {
    private readonly ICountryDetailService _countryDetailService;

    public GetAllCountryDetailHandler(ICountryDetailService countryDetailService) => _countryDetailService = countryDetailService;

    public async Task<IEnumerable<CountryDetailDTO>> Handle(GetAllCountryDetailQuery request, CancellationToken cancellationToken) =>
      await _countryDetailService.GetCountriesDetailAsync(cancellationToken);
  }
}

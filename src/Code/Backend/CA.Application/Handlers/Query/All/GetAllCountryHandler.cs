using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllCountryHandler : IRequestHandler<GetAllCountryQuery, IEnumerable<CountryDTO>>
  {
    private readonly ICountryService _countryService;
    public GetAllCountryHandler(ICountryService countryService) => _countryService = countryService;
    public async Task<IEnumerable<CountryDTO>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken) =>
      await _countryService.GetCountriesAsync(cancellationToken);
  }
}

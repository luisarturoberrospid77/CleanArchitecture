using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetCountryHandler : IRequestHandler<GetCountryQuery, CountryDTO>
  {
    private readonly ICountryService _countryService;
    public GetCountryHandler(ICountryService countryService) => _countryService = countryService;
    public async Task<CountryDTO> Handle(GetCountryQuery request, CancellationToken cancellationToken) =>
      await _countryService.FindCountryAsync(request.Id, cancellationToken);
  }
}

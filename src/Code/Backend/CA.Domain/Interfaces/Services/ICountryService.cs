using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Domain.DTO;

namespace CA.Domain.Interfaces.Services
{
  public interface ICountryService
  {
    Task<CountryDTO> FindCountryAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CountryDTO>> GetCountriesAsync(CancellationToken cancellationToken = default);
  }
}

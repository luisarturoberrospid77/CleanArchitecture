using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CA.Domain.DTO;

namespace CA.Domain.Interfaces.Services
{
  public interface ICountryDetailService
  {
    Task<CountryDetailDTO> FindCountryDetailAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CountryDetailDTO>> GetCountriesDetailAsync(CancellationToken cancellationToken = default);
  }
}

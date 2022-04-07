using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Repository;
using CA.Domain.Interfaces.Services;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
  public class CountryService : RService<CountryDTO, int,
                                Country, ICountryRepository<PatosaDbContext>,
                                PatosaDbContext>, ICountryService
  {
    public CountryService(IMapper mapper,
                          IUnitOfWork<PatosaDbContext> unitOfWork,
                          ICountryRepository<PatosaDbContext> countryRepository) : base(mapper, unitOfWork, countryRepository) { }
    public async Task<CountryDTO> FindCountryAsync(int id, CancellationToken cancellationToken = default) =>
      await GetSingleAsync(u => u.Id == id & u.IsDeleted == false, cancellationToken);
    public async Task<IEnumerable<CountryDTO>> GetCountriesAsync(CancellationToken cancellationToken = default) =>
      await GetAllAsync(cancellationToken);
  }
}

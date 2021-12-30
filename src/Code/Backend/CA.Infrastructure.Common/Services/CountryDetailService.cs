using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Services;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
  public class CountryDetailService : RService<CountryDetailDTO, int,
                                      CountryDetail, ICountryDetailRepository<PatosaDbContext>,
                                      PatosaDbContext>, ICountryDetailService
  {
    public CountryDetailService(IMapper mapper,
                                IUnitOfWork<PatosaDbContext> unitOfWork,
                                ICountryDetailRepository<PatosaDbContext> countryDetailRepository) : base(mapper, unitOfWork, countryDetailRepository) { }
    public async Task<CountryDetailDTO> FindCountryDetailAsync(int id, CancellationToken cancellationToken = default) =>
      await GetSingleAsync(u => u.Id == id & u.IsDeleted == false, cancellationToken);
    public async Task<IEnumerable<CountryDetailDTO>> GetCountriesDetailAsync(CancellationToken cancellationToken = default) =>
      await GetAllAsync(cancellationToken);
  }
}

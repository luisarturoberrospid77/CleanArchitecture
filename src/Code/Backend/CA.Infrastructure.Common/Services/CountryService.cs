using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;
using Microsoft.Extensions.Options;

using CA.Domain.DTO;
using CA.Domain.DTO.Base;
using CA.Domain.Entities;
using CA.Domain.Exceptions;
using CA.Domain.Entities.Base;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Services;
using CA.Domain.Interfaces.Management;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
    public class CountryService : RService<CountryDTO, int,
                                  Country, ICountryRepository<PatosaDbContext>,
                                  PatosaDbContext>, ICountryService
    {
        private readonly IDataShapeHelper<CountryDTO> _dataShaperHelper;

        public CountryService(IMapper mapper,
                              IUnitOfWork<PatosaDbContext> unitOfWork,
                              ICountryRepository<PatosaDbContext> countryRepository,
                              IDataShapeHelper<CountryDTO> dataShapeHelper) : base(mapper, unitOfWork, countryRepository)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<CountryDTO> FindCountryAsync(int id, CancellationToken cancellationToken = default) =>
            await GetSingleAsync(u => u.Id == id & u.IsDeleted == false, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetCountriesAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null) =>
            await _dataShaperHelper.ShapeDataAsync(await GetAllAsync(cancellationToken, fields, orderBy), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedCountriesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, Expression<Func<Country, bool>> predicate = null, string fields = null, string orderBy = null) =>
            (predicate == null) ? await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, cancellationToken, fields, orderBy), fields) :
                                    await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, fields, orderBy), fields);
    }
}

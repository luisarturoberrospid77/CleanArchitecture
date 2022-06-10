using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Entities.Base;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Services;
using CA.Domain.Interfaces.Management;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
    public class CountryService : RService<int,
                                  Country, ICountryRepository<PatosaDbContext>,
                                  PatosaDbContext>, ICountryService
    {
        private readonly IDataShapeHelper<CountryDTO> _dataShaperHelper;
        
        public CountryService(IMapper mapper,
                              IUnitOfWork<PatosaDbContext> unitOfWork,
                              ICountryRepository<PatosaDbContext> countryRepository,
                              IDataShapeHelper<CountryDTO> dataShapeHelper) : base(mapper, unitOfWork, countryRepository)
        { _dataShaperHelper = dataShapeHelper; }
        //    await GetSingleAsync(u => u.Id == id & u.IsDeleted == false, cancellationToken);
        public async Task<Country> FindCountryAsync(int id, CancellationToken cancellationToken = default) => 
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetCountriesAsync(Expression<Func<Country, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<CountryDTO>>(await GetAllAsync(predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedCountriesAsync(int pageNumber, int pageSize, Expression<Func<Country, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) => (predicate == null) ?
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<CountryDTO>>(await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken)), fields) :
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<CountryDTO>>(await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken)), fields);
    }
}

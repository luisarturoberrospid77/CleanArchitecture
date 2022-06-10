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
    public class CountryDetailService : RService<int,
                                        CountryDetail, ICountryDetailRepository<PatosaDbContext>,
                                        PatosaDbContext>, ICountryDetailService
    {
        private readonly IDataShapeHelper<CountryDetailDTO> _dataShaperHelper;
        
        public CountryDetailService(IMapper mapper,
                                    IUnitOfWork<PatosaDbContext> unitOfWork,
                                    ICountryDetailRepository<PatosaDbContext> countryDetailRepository,
                                    IDataShapeHelper<CountryDetailDTO> dataShapeHelper) : base(mapper, unitOfWork, countryDetailRepository)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<CountryDetail> FindCountryDetailAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetCountriesDetailAsync(Expression<Func<CountryDetail, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<CountryDetailDTO>>(await GetAllAsync(predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedCountriesDetailAsync(int pageNumber, int pageSize, Expression<Func<CountryDetail, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) => (predicate == null) ?
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<CountryDetailDTO>>(await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken)), fields) :
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<CountryDetailDTO>>(await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken)), fields);
    }
}

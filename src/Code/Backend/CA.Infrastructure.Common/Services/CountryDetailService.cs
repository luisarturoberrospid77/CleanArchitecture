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
    public class CountryDetailService : RService<CountryDetailDTO, int,
                                        CountryDetail, ICountryDetailRepository<PatosaDbContext>,
                                        PatosaDbContext>, ICountryDetailService
    {
        private readonly IDataShapeHelper<CountryDetailDTO> _dataShaperHelper;

        public CountryDetailService(IMapper mapper,
                                    IUnitOfWork<PatosaDbContext> unitOfWork,
                                    ICountryDetailRepository<PatosaDbContext> countryDetailRepository,
                                    IDataShapeHelper<CountryDetailDTO> dataShapeHelper) : base(mapper, unitOfWork, countryDetailRepository)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<CountryDetailDTO> FindCountryDetailAsync(int id, CancellationToken cancellationToken = default) =>
            await GetSingleAsync(u => u.Id == id & u.IsDeleted == false, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetCountriesDetailAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null) =>
            await _dataShaperHelper.ShapeDataAsync(await GetAllAsync(cancellationToken, fields, orderBy), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedCountriesDetailAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, Expression<Func<CountryDetail, bool>> predicate = null, string fields = null, string orderBy = null) =>
            (predicate == null) ? await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, cancellationToken, fields, orderBy), fields) :
                                    await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, fields, orderBy), fields);
    }
}

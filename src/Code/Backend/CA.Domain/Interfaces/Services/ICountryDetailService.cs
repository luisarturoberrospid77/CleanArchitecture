using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.Entities;
using CA.Domain.Entities.Base;

namespace CA.Domain.Interfaces.Services
{
    public interface ICountryDetailService
    {
        public int RowCount { get; }
        Task<CountryDetail> FindCountryDetailAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetCountriesDetailAsync(Expression<Func<CountryDetail, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedCountriesDetailAsync(int pageNumber, int pageSize, Expression<Func<CountryDetail, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
    }
}

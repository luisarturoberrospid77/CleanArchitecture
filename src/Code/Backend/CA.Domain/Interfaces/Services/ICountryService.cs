using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.Entities;
using CA.Domain.Entities.Base;

namespace CA.Domain.Interfaces.Services
{
    public interface ICountryService
    {
        public int RowCount { get; }
        Task<Country> FindCountryAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetCountriesAsync(Expression<Func<Country, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedCountriesAsync(int pageNumber, int pageSize, Expression<Func<Country, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
    }
}

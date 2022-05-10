using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;

namespace CA.Domain.Interfaces.Repository
{
    public interface ICountryRepository<TContext> : IBaseRepository<Country, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<Country>> GetCountriesAsync(CancellationToken cancellationToken = default);
        Task<Country> GetCountryAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Country>> GetPagedCountriesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<Country> SingleCountryAsync(Expression<Func<Country, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<Country>> FilterCountryAsync(Expression<Func<Country, bool>> predicate, CancellationToken cancellationToken = default);
    }
}

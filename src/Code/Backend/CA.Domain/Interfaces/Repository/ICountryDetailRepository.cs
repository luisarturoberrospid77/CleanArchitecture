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
  public interface ICountryDetailRepository<TContext> : IBaseRepository<CountryDetail, TContext>
    where TContext : DbContext, new()
  {
    Task<IEnumerable<CountryDetail>> GetCountryDetailAsync(CancellationToken cancellationToken = default);
    Task<CountryDetail> GetCountryDetailAsync(int id, CancellationToken cancellationToken = default);
    Task<CountryDetail> SingleCountryDetailAsync(Expression<Func<CountryDetail, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<CountryDetail>> FilterCountryDetailAsync(Expression<Func<CountryDetail, bool>> predicate, CancellationToken cancellationToken = default);
  }
}

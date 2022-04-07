using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Repository.Base;

namespace CA.Infrastructure.Common.Repositories
{
  public class CountryRepository : BaseRepository<Country, int, PatosaDbContext>,
                                   ICountryRepository<PatosaDbContext>
  {
    public CountryRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
    public async Task<IEnumerable<Country>> FilterCountryAsync(Expression<Func<Country, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterAsync(predicate, cancellationToken);
    public async Task<IEnumerable<Country>> GetCountryAsync(CancellationToken cancellationToken = default) =>
      await AllAsync(cancellationToken);
    public async Task<Country> GetCountryAsync(int id, CancellationToken cancellationToken = default) =>
      await GetByIdAsync(id, cancellationToken);
    public async Task<Country> SingleCountryAsync(Expression<Func<Country, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterSingleAsync(predicate, cancellationToken);
  }
}

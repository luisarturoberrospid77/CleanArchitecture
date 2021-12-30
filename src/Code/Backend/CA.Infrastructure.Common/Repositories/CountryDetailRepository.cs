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
  public class CountryDetailRepository : BaseRepository<CountryDetail, int, PatosaDbContext>,
                                         ICountryDetailRepository<PatosaDbContext>
  {
    public CountryDetailRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
    public async Task<IEnumerable<CountryDetail>> FilterCountryDetailAsync(Expression<Func<CountryDetail, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterAsync(predicate, cancellationToken);
    public async Task<IEnumerable<CountryDetail>> GetCountryDetailAsync(CancellationToken cancellationToken = default) =>
      await AllAsync(cancellationToken);
    public async Task<CountryDetail> GetCountryDetailAsync(int id, CancellationToken cancellationToken = default) =>
      await GetByIdAsync(id, cancellationToken);
    public async Task<CountryDetail> SingleCountryDetailAsync(Expression<Func<CountryDetail, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterSingleAsync(predicate, cancellationToken);
  }
}

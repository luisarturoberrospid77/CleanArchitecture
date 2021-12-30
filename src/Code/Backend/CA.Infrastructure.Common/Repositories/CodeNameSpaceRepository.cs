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
  public class CodeNameSpaceRepository : BaseRepository<CodeNamespace, int, PatosaDbContext>,
                                         ICodeNameSpaceRepository<PatosaDbContext>
  {
    public CodeNameSpaceRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
    public async Task AddCodeNameSpaceAsync(CodeNamespace obj, CancellationToken cancellationToken = default) =>
      await AddAsync(obj, cancellationToken);
    public async Task AddRangeCodeNameSpaceAsync(IEnumerable<CodeNamespace> obj, CancellationToken cancellationToken = default) =>
      await AddRangeAsync(obj, cancellationToken);
    public void DeleteCodeNameSpace(CodeNamespace obj) => Delete(obj);
    public async Task<IEnumerable<CodeNamespace>> FilterCodeNameSpaceAsync(Expression<Func<CodeNamespace, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterAsync(predicate, cancellationToken);
    public async Task<CodeNamespace> GetCodeNameSpaceAsync(int id, CancellationToken cancellationToken = default) =>
      await GetByIdAsync(id, cancellationToken);
    public async Task<IEnumerable<CodeNamespace>> GetCodeNameSpacesAsync(CancellationToken cancellationToken = default) =>
      await AllAsync(cancellationToken);
    public async Task<CodeNamespace> SingleCodeNameSpaceAsync(Expression<Func<CodeNamespace, bool>> predicate, CancellationToken cancellationToken = default) =>
      await FilterSingleAsync(predicate, cancellationToken);
    public void UpdateCodeNameSpace(CodeNamespace obj) => Update(obj);
  }
}

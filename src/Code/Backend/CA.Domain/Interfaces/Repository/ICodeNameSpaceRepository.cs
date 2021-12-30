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
  public interface ICodeNameSpaceRepository<TContext> : IBaseRepository<CodeNamespace, TContext>
    where TContext : DbContext, new()
  {
    Task<IEnumerable<CodeNamespace>> GetCodeNameSpacesAsync(CancellationToken cancellationToken = default);
    Task<CodeNamespace> GetCodeNameSpaceAsync(int id, CancellationToken cancellationToken = default);
    Task<CodeNamespace> SingleCodeNameSpaceAsync(Expression<Func<CodeNamespace, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<CodeNamespace>> FilterCodeNameSpaceAsync(Expression<Func<CodeNamespace, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddCodeNameSpaceAsync(CodeNamespace obj, CancellationToken cancellationToken = default);
    Task AddRangeCodeNameSpaceAsync(IEnumerable<CodeNamespace> obj, CancellationToken cancellationToken = default);
    void UpdateCodeNameSpace(CodeNamespace obj);
    void DeleteCodeNameSpace(CodeNamespace obj);
  }
}
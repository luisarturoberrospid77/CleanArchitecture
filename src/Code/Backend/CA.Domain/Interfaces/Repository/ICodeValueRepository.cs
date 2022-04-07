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
  public interface ICodeValueRepository<TContext> : IBaseRepository<CodeValue, TContext>
    where TContext : DbContext, new()
  {
    Task<IEnumerable<CodeValue>> GetCodeValueAsync(CancellationToken cancellationToken = default);
    Task<CodeValue> GetCodeValueAsync(int id, CancellationToken cancellationToken = default);
    Task<CodeValue> SingleCodeValueAsync(Expression<Func<CodeValue, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<CodeValue>> FilterCodeValueAsync(Expression<Func<CodeValue, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddCodeValueAsync(CodeValue obj, CancellationToken cancellationToken = default);
    Task AddRangeCodeValueAsync(IEnumerable<CodeValue> obj, CancellationToken cancellationToken = default);
    void UpdateCodeValue(CodeValue obj);
    void DeleteCodeValue(CodeValue obj);
  }
}
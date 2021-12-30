using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Management;

namespace CA.Domain.Interfaces.Services.Base
{
  public interface ICRUDService<TQueryDTO, TCommandDTO, TKey, TEntity, TRepoAll, TContext>
    where TEntity : class, IEntityBase<TKey>
    where TRepoAll : IBaseRepository<TEntity, TContext>
    where TContext : DbContext, new()
  {
    Task<IEnumerable<TQueryDTO>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<TQueryDTO>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
    Task<IEnumerable<TQueryDTO>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TQueryDTO> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TQueryDTO> FindAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TQueryDTO>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TQueryDTO> UpdateAsync(TCommandDTO objDTO, CancellationToken cancellationToken = default);
    Task<TQueryDTO> InsertAsync(TCommandDTO objDTO, CancellationToken cancellationToken = default);
    Task<TQueryDTO> DeleteAsync(TCommandDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
  }
}

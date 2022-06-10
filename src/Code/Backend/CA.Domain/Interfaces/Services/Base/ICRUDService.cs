using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Management;

namespace CA.Domain.Interfaces.Services.Base
{
    public interface ICRUDService<TCommandDTO, TKey, TEntity, TRepoAll, TContext> : IRService<TKey, TEntity, TRepoAll, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoAll : IBaseRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        Task<TEntity> DeleteAsync(TEntity entityObj, bool autoSave = true, CancellationToken cancellationToken = default);
        Task<TEntity> DeleteAsync(TCommandDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
        Task<TEntity> InsertAsync(TEntity entityObj, CancellationToken cancellationToken = default);
        Task<TEntity> InsertAsync(TCommandDTO objDTO, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entityObj, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TCommandDTO objDTO, CancellationToken cancellationToken = default);
    }
}

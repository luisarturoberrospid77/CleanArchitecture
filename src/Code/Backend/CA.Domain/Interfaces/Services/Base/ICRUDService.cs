using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Management;

namespace CA.Domain.Interfaces.Services.Base
{
    public interface ICRUDService<TQueryDTO, TCommandDTO, TKey, TEntity, TRepoAll, TContext> : IRService<TQueryDTO, TKey, TEntity, TRepoAll, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoAll : IBaseRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        Task<TQueryDTO> UpdateAsync(TCommandDTO objDTO, CancellationToken cancellationToken = default);
        Task<TQueryDTO> InsertAsync(TCommandDTO objDTO, CancellationToken cancellationToken = default);
        Task<TQueryDTO> DeleteAsync(TCommandDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

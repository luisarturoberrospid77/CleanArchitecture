using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Entities.Base;

namespace CA.Domain.Interfaces.Services
{
    public interface IStoreService
    {
        public int RowCount { get; }
        Task<Store> FindStoreAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetStoresAsync(Expression<Func<Store, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedStoresAsync(int pageNumber, int pageSize, Expression<Func<Store, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<Store> InsertStoreAsync(CreateStoreDTO objDTO, CancellationToken cancellationToken = default);
        Task<Store> UpdateStoreAsync(UpdateStoreDTO objDTO, CancellationToken cancellationToken = default);
        Task<Store> DeleteStoreAsync(DeleteStoreDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

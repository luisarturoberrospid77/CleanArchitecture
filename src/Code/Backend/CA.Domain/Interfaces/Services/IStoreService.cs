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
        Task<StoreDTO> FindStoreAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetStoresAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedStoresAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, Expression<Func<Store, bool>> predicate = null, string fields = null, string orderBy = null);
        Task<CreateStoreDTO> InsertStoreAsync(CreateStoreDTO objDTO, CancellationToken cancellationToken = default);
        Task<UpdateStoreDTO> UpdateStoreAsync(UpdateStoreDTO objDTO, CancellationToken cancellationToken = default);
        Task<DeleteStoreDTO> DeleteStoreAsync(DeleteStoreDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

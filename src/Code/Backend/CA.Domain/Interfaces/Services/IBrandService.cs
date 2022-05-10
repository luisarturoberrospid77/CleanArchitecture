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
    public interface IBrandService
    {
        public int RowCount { get; }
        Task<BrandDTO> FindBrandAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetBrandsAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedBrandsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, Expression<Func<Brand, bool>> predicate = null, string fields = null, string orderBy = null);
        Task<CreateBrandDTO> InsertBrandAsync(CreateBrandDTO objDTO, CancellationToken cancellationToken = default);
        Task<UpdateBrandDTO> UpdateBrandAsync(UpdateBrandDTO objDTO, CancellationToken cancellationToken = default);
        Task<DeleteBrandDTO> DeleteBrandAsync(DeleteBrandDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

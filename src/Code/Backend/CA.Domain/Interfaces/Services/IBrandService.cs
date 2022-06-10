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
        Task<Brand> FindBrandAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetBrandsAsync(Expression<Func<Brand, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedBrandsAsync(int pageNumber, int pageSize, Expression<Func<Brand, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<Brand> InsertBrandAsync(CreateBrandDTO objDTO, CancellationToken cancellationToken = default);
        Task<Brand> UpdateBrandAsync(UpdateBrandDTO objDTO, CancellationToken cancellationToken = default);
        Task<Brand> DeleteBrandAsync(DeleteBrandDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

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
    public interface ICategoryService
    {
        public int RowCount { get; }
        Task<CategoryDTO> FindCategoryAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetCategoriesAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedCategoriesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, Expression<Func<MenuCategory, bool>> predicate = null, string fields = null, string orderBy = null);
    }
}

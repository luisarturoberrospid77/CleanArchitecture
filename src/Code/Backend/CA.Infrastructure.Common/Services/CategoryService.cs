using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Entities.Base;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Services;
using CA.Domain.Interfaces.Management;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
    public class CategoryService : RService<int,
                                            MenuCategory, ICategoryRepository<PatosaDbContext>,
                                            PatosaDbContext>, ICategoryService
    {
        private readonly IDataShapeHelper<CategoryDTO> _dataShaperHelper;

        public CategoryService(IMapper mapper,
                               IUnitOfWork<PatosaDbContext> unitOfWork,
                               ICategoryRepository<PatosaDbContext> categoryRepository,
                               IDataShapeHelper<CategoryDTO> dataShapeHelper) : base(mapper, unitOfWork, categoryRepository)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<MenuCategory> FindCategoryAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetCategoriesAsync(Expression<Func<MenuCategory, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<CategoryDTO>>(await GetAllAsync(predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedCategoriesAsync(int pageNumber, int pageSize, Expression<Func<MenuCategory, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) => (predicate == null) ?
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<CategoryDTO>>(await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken)), fields) :
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<CategoryDTO>>(await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken)), fields);
    }
}

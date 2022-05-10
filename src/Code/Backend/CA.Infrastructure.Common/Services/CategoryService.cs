using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;
using Microsoft.Extensions.Options;

using CA.Domain.DTO;
using CA.Domain.DTO.Base;
using CA.Domain.Entities;
using CA.Domain.Exceptions;
using CA.Domain.Entities.Base;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Services;
using CA.Domain.Interfaces.Management;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
    public class CategoryService : RService<CategoryDTO, int,
                                            MenuCategory, ICategoryRepository<PatosaDbContext>,
                                            PatosaDbContext>, ICategoryService
    {
        private readonly IDataShapeHelper<CategoryDTO> _dataShaperHelper;

        public CategoryService(IMapper mapper,
                               IUnitOfWork<PatosaDbContext> unitOfWork,
                               ICategoryRepository<PatosaDbContext> categoryRepository,
                               IDataShapeHelper<CategoryDTO> dataShapeHelper) : base(mapper, unitOfWork, categoryRepository)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<CategoryDTO> FindCategoryAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetCategoriesAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null) =>
            await _dataShaperHelper.ShapeDataAsync(await GetAllAsync(cancellationToken, fields, orderBy), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedCategoriesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, Expression<Func<MenuCategory, bool>> predicate = null, string fields = null, string orderBy = null) =>
            (predicate == null) ? await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, cancellationToken, fields, orderBy), fields) :
                                    await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, fields, orderBy), fields);
    }
}

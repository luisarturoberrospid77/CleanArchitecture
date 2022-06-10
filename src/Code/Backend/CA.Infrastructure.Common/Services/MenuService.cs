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
    public class MenuService : RService<int,
                                        MenuSystem, IMenuRepository<PatosaDbContext>,
                                        PatosaDbContext>, IMenuService
    {
        private readonly IDataShapeHelper<MenuDTO> _dataShaperHelper;

        public MenuService(IMapper mapper,
                           IUnitOfWork<PatosaDbContext> unitOfWork,
                           IMenuRepository<PatosaDbContext> menuRepository,
                           IDataShapeHelper<MenuDTO> dataShapeHelper) : base(mapper, unitOfWork, menuRepository)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<MenuSystem> FindMenuOptionAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetMenuOptionsAsync(Expression<Func<MenuSystem, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<MenuDTO>>(await GetAllAsync(predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedMenuOptionsAsync(int pageNumber, int pageSize, Expression<Func<MenuSystem, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) => (predicate == null) ?
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<MenuDTO>>(await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken)), fields) :
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<MenuDTO>>(await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken)), fields);
    }
}

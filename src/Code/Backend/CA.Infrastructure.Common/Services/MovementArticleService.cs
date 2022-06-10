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
    public class MovementArticleService : RService<int,
                                                   MovementArticle, IMovementArticleRepository<PatosaDbContext>,
                                                   PatosaDbContext>, IMovementArticleService
    {
        private readonly IDataShapeHelper<MovementArticleDTO> _dataShaperHelper;

        public MovementArticleService(IMapper mapper,
                                      IUnitOfWork<PatosaDbContext> unitOfWork,
                                      IMovementArticleRepository<PatosaDbContext> movementArticleRepository,
                                      IDataShapeHelper<MovementArticleDTO> dataShapeHelper) : base(mapper, unitOfWork, movementArticleRepository)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<MovementArticle> FindMovementArticleAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetMovementArticlesAsync(Expression<Func<MovementArticle, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<MovementArticleDTO>>(await GetAllAsync(predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedMovementArticlesAsync(int pageNumber, int pageSize, Expression<Func<MovementArticle, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) => (predicate == null) ?
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<MovementArticleDTO>>(await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken)), fields) :
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<MovementArticleDTO>>(await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken)), fields);
    }
}

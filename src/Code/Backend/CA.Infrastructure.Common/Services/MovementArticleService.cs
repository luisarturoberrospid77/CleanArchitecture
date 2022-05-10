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
    public class MovementArticleService : RService<MovementArticleDTO, int,
                                                   MovementArticle, IMovementArticleRepository<PatosaDbContext>,
                                                   PatosaDbContext>, IMovementArticleService
    {
        private readonly IDataShapeHelper<MovementArticleDTO> _dataShaperHelper;

        public MovementArticleService(IMapper mapper,
                                      IUnitOfWork<PatosaDbContext> unitOfWork,
                                      IMovementArticleRepository<PatosaDbContext> movementArticleRepository,
                                      IDataShapeHelper<MovementArticleDTO> dataShapeHelper) : base(mapper, unitOfWork, movementArticleRepository)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<MovementArticleDTO> FindMovementArticleAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetMovementArticlesAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null) =>
            await _dataShaperHelper.ShapeDataAsync(await GetAllAsync(cancellationToken, fields, orderBy), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedMovementArticlesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, Expression<Func<MovementArticle, bool>> predicate = null, string fields = null, string orderBy = null) =>
            (predicate == null) ? await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, cancellationToken, fields, orderBy), fields) :
                                    await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, fields, orderBy), fields);
    }
}

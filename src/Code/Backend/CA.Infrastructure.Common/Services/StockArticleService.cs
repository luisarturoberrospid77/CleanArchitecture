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
    public class StockArticleService : RService<int,
                                               StockArticle, IStockArticleRepository<PatosaDbContext>,
                                               PatosaDbContext>, IStockArticleService
    {
        private readonly IDataShapeHelper<StockArticleDTO> _dataShaperHelper;

        public StockArticleService(IMapper mapper,
                                   IUnitOfWork<PatosaDbContext> unitOfWork,
                                   IStockArticleRepository<PatosaDbContext> stockArticleRepository,
                                   IDataShapeHelper<StockArticleDTO> dataShapeHelper) : base(mapper, unitOfWork, stockArticleRepository)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<StockArticle> FindStockArticleAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetStockArticlesAsync(Expression<Func<StockArticle, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<StockArticleDTO>>(await GetAllAsync(predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedStockArticlesAsync(int pageNumber, int pageSize, Expression<Func<StockArticle, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) => (predicate == null) ?
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<StockArticleDTO>>(await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken)), fields) :
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<StockArticleDTO>>(await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken)), fields);    }
}

using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Repository;
using CA.Domain.Interfaces.Services;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
  public class StockArticleService : RService<StockArticleDTO, int,
                                             StockArticle, IStockArticleRepository<PatosaDbContext>,
                                             PatosaDbContext>, IStockArticleService
  {
    public StockArticleService(IMapper mapper,
                               IUnitOfWork<PatosaDbContext> unitOfWork,
                               IStockArticleRepository<PatosaDbContext> stockArticleRepository) : base(mapper, unitOfWork, stockArticleRepository) { }
    public async Task<StockArticleDTO> FindStockArticleAsync(int id, CancellationToken cancellationToken = default) =>
      await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<StockArticleDTO>> GetStockArticlesAsync(CancellationToken cancellationToken = default) =>
      await GetAllAsync(cancellationToken);
  }
}

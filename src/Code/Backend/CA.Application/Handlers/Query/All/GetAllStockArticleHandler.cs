using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllStockArticleHandler : IRequestHandler<GetAllStockArticleQuery, IEnumerable<StockArticleDTO>>
  {
    private readonly IStockArticleService _stockArticleService;
    public GetAllStockArticleHandler(IStockArticleService stockArticleService) => _stockArticleService = stockArticleService;
    public async Task<IEnumerable<StockArticleDTO>> Handle(GetAllStockArticleQuery request, CancellationToken cancellationToken) =>
      await _stockArticleService.GetStockArticlesAsync(cancellationToken);
  }
}

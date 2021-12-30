using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetStockArticleHandler : IRequestHandler<GetStockArticleQuery, StockArticleDTO>
  {
    private readonly IStockArticleService _stockArticleService;
    public GetStockArticleHandler(IStockArticleService stockArticleService) => _stockArticleService = stockArticleService;
    public async Task<StockArticleDTO> Handle(GetStockArticleQuery request, CancellationToken cancellationToken) =>
      await _stockArticleService.FindStockArticleAsync(request.Id, cancellationToken);
  }
}

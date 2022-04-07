using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllStockArticleQuery : IRequest<IEnumerable<StockArticleDTO>> { }
  public class GetStockArticleQuery : IRequest<StockArticleDTO>
  {
    public int Id { get; }
    public GetStockArticleQuery(int id) => Id = id;
  }
}

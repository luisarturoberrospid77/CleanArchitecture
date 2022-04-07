using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;
using Microsoft.AspNetCore.Mvc;

using CA.Domain.DTO;
using CA.Application.Queries;

namespace CA.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StockArticleController : ControllerBase
  {
    private readonly IMediator _mediator;
    public StockArticleController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<StockArticleDTO>> GetStockArticles() => await _mediator.Send(new GetAllStockArticleQuery());
    [HttpGet("{id}")]
    public async Task<StockArticleDTO> GetStockArticle(int id) => await _mediator.Send(new GetStockArticleQuery(id));
  }
}

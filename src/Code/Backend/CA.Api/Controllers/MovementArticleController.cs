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
  public class MovementArticleController : ControllerBase
  {
    private readonly IMediator _mediator;
    public MovementArticleController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<MovementArticleDTO>> GetMovementArticles() => await _mediator.Send(new GetAllMovementArticleQuery());
    [HttpGet("{id}")]
    public async Task<MovementArticleDTO> GetMovementArticle(int id) => await _mediator.Send(new GetMovementArticleQuery(id));
  }
}

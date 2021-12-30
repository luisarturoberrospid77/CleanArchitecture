using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;
using Microsoft.AspNetCore.Mvc;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Application.Queries;

namespace CA.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ArticleController : ControllerBase
  {
    private readonly IMediator _mediator;
    public ArticleController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<ArticleDTO>> GetArticles() => await _mediator.Send(new GetAllArticleQuery());
    [HttpGet("{id}")]
    public async Task<ArticleDTO> GetArticle(int id) => await _mediator.Send(new GetArticleQuery(id));
    [HttpPost]
    public async Task<ApiResponse<CreateArticleDTO>> Post(CreateArticleDTO command) => await _mediator.Send(command);
    [HttpPut]
    public async Task<ApiResponse<UpdateArticleDTO>> Put(UpdateArticleDTO command) => await _mediator.Send(command);
    [HttpDelete]
    public async Task<ApiResponse<DeleteArticleDTO>> Delete(DeleteArticleDTO command) => await _mediator.Send(command);
  }
}

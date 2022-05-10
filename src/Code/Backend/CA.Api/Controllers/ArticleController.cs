using System.Threading.Tasks;

using MediatR;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

using CA.Domain.DTO;
using CA.Domain.Custom;
using CA.Domain.Wrappers;
using CA.Application.Queries;
using CA.Domain.Entities.Base;

namespace CA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ArticleController(IMediator mediator) => _mediator = mediator;
        [HttpGet]
        public async Task<ApiResponse<MetaData<ShapedEntityDTO>>> Get([FromQuery] GetAllArticleParameter filter)
        {
            var _response = await _mediator.Send(new GetAllArticleQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber, Fields = filter.Fields, OrderBy = filter.OrderBy, Search = filter.Search, Route = Request.Path.Value });
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject((_response.Data.Paging.CurrentPage, _response.Data.Paging.PageSize, _response.Data.Paging.TotalCount)));
            return _response;
        }
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

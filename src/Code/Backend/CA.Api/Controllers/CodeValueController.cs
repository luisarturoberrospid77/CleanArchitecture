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
    public class CodeValueController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CodeValueController(IMediator mediator) => _mediator = mediator;
        [HttpGet]
        public async Task<ApiResponse<MetaData<ShapedEntityDTO>>> Get([FromQuery] GetAllCodeValueParameter filter)
        {
            var _response = await _mediator.Send(new GetAllCodeValueQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber, Fields = filter.Fields, OrderBy = filter.OrderBy, Search = filter.Search, Route = Request.Path.Value });
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject((_response.Data.Paging.CurrentPage, _response.Data.Paging.PageSize, _response.Data.Paging.TotalCount)));
            return _response;
        }
        [HttpGet("{id}")]
        public async Task<CodeValueDTO> GetCodeValue(int id) => await _mediator.Send(new GetCodeValueQuery(id));
        [HttpPost]
        public async Task<ApiResponse<CreateCodeValueDTO>> Post(CreateCodeValueDTO command) => await _mediator.Send(command);
        [HttpPut]
        public async Task<ApiResponse<UpdateCodeValueDTO>> Put(UpdateCodeValueDTO command) => await _mediator.Send(command);
        [HttpDelete]
        public async Task<ApiResponse<DeleteCodeValueDTO>> Delete(DeleteCodeValueDTO command) => await _mediator.Send(command);
    }
}

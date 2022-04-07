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
  public class CodeNameSpaceController : ControllerBase
  {
    private readonly IMediator _mediator;
    public CodeNameSpaceController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<CodeNameSpaceDTO>> GetCodeValues() => await _mediator.Send(new GetAllCodeNameSpaceQuery());
    [HttpGet("{id}")]
    public async Task<CodeNameSpaceDTO> GetCodeValue(int id) => await _mediator.Send(new GetCodeNameSpaceQuery(id));
    [HttpPost]
    public async Task<ApiResponse<CreateCodeNameSpaceDTO>> Post(CreateCodeNameSpaceDTO command) => await _mediator.Send(command);
    [HttpPut]
    public async Task<ApiResponse<UpdateCodeNameSpaceDTO>> Put(UpdateCodeNameSpaceDTO command) => await _mediator.Send(command);
    [HttpDelete]
    public async Task<ApiResponse<DeleteCodeNameSpaceDTO>> Delete(DeleteCodeNameSpaceDTO command) => await _mediator.Send(command);
  }
}

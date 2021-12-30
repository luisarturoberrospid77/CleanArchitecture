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
  public class CodeValueController : ControllerBase
  {
    private readonly IMediator _mediator;
    public CodeValueController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<CodeValueDTO>> GetCodeValues() => await _mediator.Send(new GetAllCodeValueQuery());
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

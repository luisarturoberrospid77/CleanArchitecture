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
  public class StoreController : ControllerBase
  {
    private readonly IMediator _mediator;
    public StoreController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<StoreDTO>> GetStores() => await _mediator.Send(new GetAllStoreQuery());
    [HttpGet("{id}")]
    public async Task<StoreDTO> GetStore(int id) => await _mediator.Send(new GetStoreQuery(id));
    [HttpPost]
    public async Task<ApiResponse<CreateStoreDTO>> Post(CreateStoreDTO command) => await _mediator.Send(command);
    [HttpPut]
    public async Task<ApiResponse<UpdateStoreDTO>> Put(UpdateStoreDTO command) => await _mediator.Send(command);
    [HttpDelete]
    public async Task<ApiResponse<DeleteStoreDTO>> Delete(DeleteStoreDTO command) => await _mediator.Send(command);
  }
}

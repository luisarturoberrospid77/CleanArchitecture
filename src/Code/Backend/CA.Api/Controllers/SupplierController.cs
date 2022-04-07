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
  public class SupplierController : ControllerBase
  {
    private readonly IMediator _mediator;
    public SupplierController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<SupplierDTO>> GetSuppliers() => await _mediator.Send(new GetAllSupplierQuery());
    [HttpGet("{id}")]
    public async Task<SupplierDTO> GetSupplier(int id) => await _mediator.Send(new GetSupplierQuery(id));
    [HttpPost]
    public async Task<ApiResponse<CreateSupplierDTO>> Post(CreateSupplierDTO command) => await _mediator.Send(command);
    [HttpPut]
    public async Task<ApiResponse<UpdateSupplierDTO>> Put(UpdateSupplierDTO command) => await _mediator.Send(command);
    [HttpDelete]
    public async Task<ApiResponse<DeleteSupplierDTO>> Delete(DeleteSupplierDTO command) => await _mediator.Send(command);
  }
}

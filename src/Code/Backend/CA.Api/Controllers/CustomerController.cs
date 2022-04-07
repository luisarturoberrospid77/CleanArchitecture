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
  public class CustomerController : ControllerBase
  {
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<CustomerDTO>> GetArticles() => await _mediator.Send(new GetAllCustomerQuery());
    [HttpGet("{id}")]
    public async Task<CustomerDTO> GetArticles(int id) => await _mediator.Send(new GetCustomerQuery(id));
    [HttpPost]
    public async Task<ApiResponse<CreateCustomerDTO>> Post(CreateCustomerDTO command) => await _mediator.Send(command);
    [HttpPut]
    public async Task<ApiResponse<UpdateCustomerDTO>> Put(UpdateCustomerDTO command) => await _mediator.Send(command);
    [HttpDelete]
    public async Task<ApiResponse<DeleteCustomerDTO>> Delete(DeleteCustomerDTO command) => await _mediator.Send(command);
  }
}

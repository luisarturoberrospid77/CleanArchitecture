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
  public class BrandController : ControllerBase
  {
    private readonly IMediator _mediator;
    public BrandController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<BrandDTO>> GetBrands() => await _mediator.Send(new GetAllBrandQuery());
    [HttpGet("{id}")]
    public async Task<BrandDTO> GetBrand(int id) => await _mediator.Send(new GetBrandQuery(id));
    [HttpPost]
    public async Task<ApiResponse<CreateBrandDTO>> Post(CreateBrandDTO command) => await _mediator.Send(command);
    [HttpPut]
    public async Task<ApiResponse<UpdateBrandDTO>> Put(UpdateBrandDTO command) => await _mediator.Send(command);
    [HttpDelete]
    public async Task<ApiResponse<DeleteBrandDTO>> Delete(DeleteBrandDTO command) => await _mediator.Send(command);
  }
}

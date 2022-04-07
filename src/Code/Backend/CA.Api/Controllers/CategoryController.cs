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
  public class CategoryController : ControllerBase
  {
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<CategoryDTO>> GetCategories() => await _mediator.Send(new GetAllCategoryQuery());
    [HttpGet("{id}")]
    public async Task<CategoryDTO> GetCategory(int id) => await _mediator.Send(new GetCategoryQuery(id));
  }
}

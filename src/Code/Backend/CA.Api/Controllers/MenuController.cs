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
  public class MenuController : ControllerBase
  {
    private readonly IMediator _mediator;
    public MenuController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<MenuDTO>> GetMenuOptions() => await _mediator.Send(new GetAllMenuQuery());
    [HttpGet("{id}")]
    public async Task<MenuDTO> GetMenuOption(int id) => await _mediator.Send(new GetMenuQuery(id));
  }
}

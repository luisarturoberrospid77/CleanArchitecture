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
  public class CountryController : ControllerBase
  {
    private readonly IMediator _mediator;
    public CountryController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<CountryDTO>> GetCountries() => await _mediator.Send(new GetAllCountryQuery());
    [HttpGet("{id}")]
    public async Task<CountryDTO> GetCountry(int id) => await _mediator.Send(new GetCountryQuery(id));
  }
}

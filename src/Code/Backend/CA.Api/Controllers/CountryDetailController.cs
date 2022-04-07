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
  public class CountryDetailController : ControllerBase
  {
    private readonly IMediator _mediator;
    public CountryDetailController(IMediator mediator) => _mediator = mediator;
    [HttpGet]
    public async Task<IEnumerable<CountryDetailDTO>> GetCountriesDetail() => await _mediator.Send(new GetAllCountryDetailQuery());
    [HttpGet("{id}")]
    public async Task<CountryDetailDTO> GetCountryDetail(int id) => await _mediator.Send(new GetCountryDetailQuery(id));
  }
}

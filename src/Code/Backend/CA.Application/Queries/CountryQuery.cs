using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllCountryQuery : IRequest<IEnumerable<CountryDTO>> { }
  public class GetCountryQuery : IRequest<CountryDTO>
  {
    public int Id { get; }
    public GetCountryQuery(int id) => Id = id;
  }
}

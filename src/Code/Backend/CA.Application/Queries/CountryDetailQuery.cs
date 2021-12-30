using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllCountryDetailQuery : IRequest<IEnumerable<CountryDetailDTO>> { }
  public class GetCountryDetailQuery : IRequest<CountryDetailDTO>
  {
    public int Id { get; }
    public GetCountryDetailQuery(int id) => Id = id;
  }
}

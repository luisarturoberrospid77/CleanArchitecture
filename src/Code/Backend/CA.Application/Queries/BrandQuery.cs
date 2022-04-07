using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllBrandQuery : IRequest<IEnumerable<BrandDTO>> { }
  public class GetBrandQuery : IRequest<BrandDTO>
  {
    public int Id { get; }
    public GetBrandQuery(int id) => Id = id;
  }
}

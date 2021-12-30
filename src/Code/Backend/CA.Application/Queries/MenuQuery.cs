using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllMenuQuery : IRequest<IEnumerable<MenuDTO>> { }
  public class GetMenuQuery : IRequest<MenuDTO>
  {
    public int Id { get; }
    public GetMenuQuery(int id) => Id = id;
  }
}

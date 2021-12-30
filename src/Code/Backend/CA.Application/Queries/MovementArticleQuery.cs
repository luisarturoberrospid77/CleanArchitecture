using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllMovementArticleQuery : IRequest<IEnumerable<MovementArticleDTO>> { }
  public class GetMovementArticleQuery : IRequest<MovementArticleDTO>
  {
    public int Id { get; }
    public GetMovementArticleQuery(int id) => Id = id;
  }
}

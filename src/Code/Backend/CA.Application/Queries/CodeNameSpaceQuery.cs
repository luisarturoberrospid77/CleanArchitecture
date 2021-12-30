using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllCodeNameSpaceQuery : IRequest<IEnumerable<CodeNameSpaceDTO>> { }
  public class GetCodeNameSpaceQuery : IRequest<CodeNameSpaceDTO>
  {
    public int Id { get; }
    public GetCodeNameSpaceQuery(int id) => Id = id;
  }
}

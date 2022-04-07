using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllCodeValueQuery : IRequest<IEnumerable<CodeValueDTO>> { }
  public class GetCodeValueQuery : IRequest<CodeValueDTO>
  {
    public int Id { get; }
    public GetCodeValueQuery(int id) => Id = id;
  }
}

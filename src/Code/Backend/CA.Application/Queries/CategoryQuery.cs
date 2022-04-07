using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllCategoryQuery : IRequest<IEnumerable<CategoryDTO>> { }
  public class GetCategoryQuery : IRequest<CategoryDTO>
  {
    public int Id { get; }
    public GetCategoryQuery(int id) => Id = id;
  }
}

using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllStoreQuery : IRequest<IEnumerable<StoreDTO>> { }
  public class GetStoreQuery : IRequest<StoreDTO>
  {
    public int Id { get; }
    public GetStoreQuery(int id) => Id = id;
  }
}

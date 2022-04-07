using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllSupplierQuery : IRequest<IEnumerable<SupplierDTO>> { }
  public class GetSupplierQuery : IRequest<SupplierDTO>
  {
    public int Id { get; }
    public GetSupplierQuery(int id) => Id = id;
  }
}

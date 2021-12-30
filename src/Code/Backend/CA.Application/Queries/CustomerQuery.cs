using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllCustomerQuery : IRequest<IEnumerable<CustomerDTO>> { }
  public class GetCustomerQuery : IRequest<CustomerDTO>
  {
    public int Id { get; }
    public GetCustomerQuery(int id) => Id = id;
  }
}

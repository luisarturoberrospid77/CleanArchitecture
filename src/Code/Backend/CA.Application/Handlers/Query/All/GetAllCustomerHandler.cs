using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<CustomerDTO>>
  {
    private readonly ICustomerService _customerService;
    public GetAllCustomerHandler(ICustomerService customerService) => _customerService = customerService;
    public async Task<IEnumerable<CustomerDTO>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken) =>
      await _customerService.GetCustomersAsync(cancellationToken);
  }
}

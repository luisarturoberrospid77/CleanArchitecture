using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, CustomerDTO>
    {
        private readonly ICustomerService _customerService;
        public GetCustomerHandler(ICustomerService customerService) => _customerService = customerService;
        public async Task<CustomerDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken) =>
            await _customerService.FindCustomerAsync(request.Id, cancellationToken);
    }
}

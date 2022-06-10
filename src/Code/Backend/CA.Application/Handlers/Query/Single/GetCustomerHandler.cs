using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, CustomerDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService; 
        public GetCustomerHandler(ICustomerService customerService, IMapper mapper) =>
            (_customerService, _mapper) = (customerService, mapper);
        public async Task<CustomerDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken) => 
            _mapper.Map<CustomerDTO>(await _customerService.FindCustomerAsync(request.Id, cancellationToken));
    }
}

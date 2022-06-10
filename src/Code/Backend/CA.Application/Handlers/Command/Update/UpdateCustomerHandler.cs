using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerDTO, ApiResponse<UpdateCustomerDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        public UpdateCustomerHandler(ICustomerService customerService, IMapper mapper) =>
            (_customerService, _mapper) = (customerService, mapper);
        public async Task<ApiResponse<UpdateCustomerDTO>> Handle(UpdateCustomerDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UpdateCustomerDTO>(await _customerService.UpdateCustomerAsync(request, cancellationToken));
            return new ApiResponse<UpdateCustomerDTO>(entity, $"The customer with Id {entity.Id} was successfully updated.");
        }
    }
}

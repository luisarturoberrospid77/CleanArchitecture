using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
  public class CreateCustomerHandler : IRequestHandler<CreateCustomerDTO, ApiResponse<CreateCustomerDTO>>
  {
    private readonly ICustomerService _customerService;
    public CreateCustomerHandler(ICustomerService customerService) => _customerService = customerService;
    public async Task<ApiResponse<CreateCustomerDTO>> Handle(CreateCustomerDTO request, CancellationToken cancellationToken)
    {
      var entity = await _customerService.InsertCustomerAsync(request, cancellationToken);
      return new ApiResponse<CreateCustomerDTO>(entity, $"The customer with name '{entity.FirstName + " " + entity.LastName}' was created successfully.");
    }
  }
}

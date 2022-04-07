using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
  public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerDTO, ApiResponse<DeleteCustomerDTO>>
  {
    private readonly ICustomerService _customerService;
    public DeleteCustomerHandler(ICustomerService customerService) => _customerService = customerService;
    public async Task<ApiResponse<DeleteCustomerDTO>> Handle(DeleteCustomerDTO request, CancellationToken cancellationToken)
    {
      var entity = await _customerService.DeleteCustomerAsync(request, request.AutoSave, cancellationToken);
      return new ApiResponse<DeleteCustomerDTO>(entity, $"The customer with Id {entity.Id} was successfully deleted.");
    }
  }
}

using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierDTO, ApiResponse<UpdateSupplierDTO>>
    {
        private readonly ISupplierService _supplierService;
        public UpdateSupplierHandler(ISupplierService supplierService) => _supplierService = supplierService;
        public async Task<ApiResponse<UpdateSupplierDTO>> Handle(UpdateSupplierDTO request, CancellationToken cancellationToken)
        {
            var entity = await _supplierService.UpdateSupplierAsync(request, cancellationToken);
            return new ApiResponse<UpdateSupplierDTO>(entity, $"The supplier with Id {entity.Id} was successfully updated.");
        }
    }
}

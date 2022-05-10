using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierDTO, ApiResponse<DeleteSupplierDTO>>
    {
        private readonly ISupplierService _supplierService;
        public DeleteSupplierHandler(ISupplierService supplierService) => _supplierService = supplierService;
        public async Task<ApiResponse<DeleteSupplierDTO>> Handle(DeleteSupplierDTO request, CancellationToken cancellationToken)
        {
            var entity = await _supplierService.DeleteSupplierAsync(request, request.AutoSave, cancellationToken);
            return new ApiResponse<DeleteSupplierDTO>(entity, $"The supplier with Id {entity.Id} was successfully deleted.");
        }
    }
}

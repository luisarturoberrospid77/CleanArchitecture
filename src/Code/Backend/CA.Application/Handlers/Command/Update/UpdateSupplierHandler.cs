using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierDTO, ApiResponse<UpdateSupplierDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierService _supplierService;
        public UpdateSupplierHandler(ISupplierService supplierService, IMapper mapper) =>
            (_supplierService, _mapper) = (supplierService, mapper);
        public async Task<ApiResponse<UpdateSupplierDTO>> Handle(UpdateSupplierDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UpdateSupplierDTO>(await _supplierService.UpdateSupplierAsync(request, cancellationToken));
            return new ApiResponse<UpdateSupplierDTO>(entity, $"The supplier with Id {entity.Id} was successfully updated.");
        }
    }
}

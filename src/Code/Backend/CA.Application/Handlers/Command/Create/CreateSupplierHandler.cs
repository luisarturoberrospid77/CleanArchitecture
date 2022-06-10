using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class CreateSupplierHandler : IRequestHandler<CreateSupplierDTO, ApiResponse<CreateSupplierDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierService _supplierService;
        public CreateSupplierHandler(ISupplierService supplierService, IMapper mapper) =>
            (_supplierService, _mapper) = (supplierService, mapper);
        public async Task<ApiResponse<CreateSupplierDTO>> Handle(CreateSupplierDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateSupplierDTO>(await _supplierService.InsertSupplierAsync(request, cancellationToken));
            return new ApiResponse<CreateSupplierDTO>(entity, $"The supplier with name '{entity.Name}' was created successfully.");
        }
    }
}

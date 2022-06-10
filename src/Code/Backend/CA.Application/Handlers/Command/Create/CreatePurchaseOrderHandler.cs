using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class CreatePurchaseOrderHandler : IRequestHandler<CreatePurchaseDTO, ApiResponse<CreatePurchaseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseOrderService _purchaseOrderService;
        public CreatePurchaseOrderHandler(IPurchaseOrderService purchaseOrderService, IMapper mapper) =>
            (_purchaseOrderService, _mapper) = (purchaseOrderService, mapper);
        public async Task<ApiResponse<CreatePurchaseDTO>> Handle(CreatePurchaseDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreatePurchaseDTO>(await _purchaseOrderService.InsertPurchaseAsync(request, cancellationToken));
            return new ApiResponse<CreatePurchaseDTO>(entity, $"The order purchase for supplier id '{entity.SupplierId}' was created successfully.");
        }
    }
}

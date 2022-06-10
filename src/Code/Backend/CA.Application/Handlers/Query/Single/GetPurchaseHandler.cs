using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetPurchaseHandler : IRequestHandler<GetPurchaseQuery, PurchaseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseOrderService _purchaseOrderService;
        public GetPurchaseHandler(IPurchaseOrderService purchaseOrderService, IMapper mapper) =>
            (_purchaseOrderService, _mapper) = (purchaseOrderService, mapper);
        public async Task<PurchaseDTO> Handle(GetPurchaseQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<PurchaseDTO>(await _purchaseOrderService.FindPurchaseAsync(request.Id, cancellationToken));
    }
}

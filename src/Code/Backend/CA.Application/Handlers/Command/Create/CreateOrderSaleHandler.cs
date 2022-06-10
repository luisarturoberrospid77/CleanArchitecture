using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class CreateOrderSaleHandler : IRequestHandler<CreateSaleDTO, ApiResponse<CreateSaleDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ISaleOrderService _saleOrderService;
        public CreateOrderSaleHandler(ISaleOrderService saleOrderService, IMapper mapper) =>
            (_saleOrderService, _mapper) = (saleOrderService, mapper);

        public async Task<ApiResponse<CreateSaleDTO>> Handle(CreateSaleDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateSaleDTO>(await _saleOrderService.InsertOrderSaleAsync(request, cancellationToken));
            return new ApiResponse<CreateSaleDTO>(entity, $"The order sale for customer id '{entity.CustomerId}' was created successfully.");
        }
    }
}

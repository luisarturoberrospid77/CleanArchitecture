using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetOrderSaleHandler : IRequestHandler<GetSaleOrderQuery, OrderDTO>
    {
        private readonly IMapper _mapper;
        private readonly ISaleOrderService _saleOrderService;
        public GetOrderSaleHandler(ISaleOrderService saleOrderService, IMapper mapper) =>
            (_saleOrderService, _mapper) = (saleOrderService, mapper);
        public async Task<OrderDTO> Handle(GetSaleOrderQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<OrderDTO>(await _saleOrderService.FindOrderSaleAsync(request.Id, cancellationToken));
    }
}

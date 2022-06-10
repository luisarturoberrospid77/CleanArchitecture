using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetStockArticleHandler : IRequestHandler<GetStockArticleQuery, StockArticleDTO>
    {
        private readonly IMapper _mapper;
        private readonly IStockArticleService _stockArticleService;
        public GetStockArticleHandler(IStockArticleService stockArticleService, IMapper mapper) =>
            (_stockArticleService, _mapper) = (stockArticleService, mapper);
        public async Task<StockArticleDTO> Handle(GetStockArticleQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<StockArticleDTO>(await _stockArticleService.FindStockArticleAsync(request.Id, cancellationToken));
    }
}

using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetBrandHandler : IRequestHandler<GetBrandQuery, BrandDTO>
    {
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;
        public GetBrandHandler(IBrandService brandService, IMapper mapper) =>
            (_brandService, _mapper) = (brandService, mapper);
        public async Task<BrandDTO> Handle(GetBrandQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<BrandDTO>(await _brandService.FindBrandAsync(request.Id, cancellationToken));
    }
}

using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetCountryDetailHandler : IRequestHandler<GetCountryDetailQuery, CountryDetailDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICountryDetailService _countryDetailService;
        public GetCountryDetailHandler(ICountryDetailService countryDetailService, IMapper mapper) =>
            (_countryDetailService, _mapper) = (countryDetailService, mapper);
        public async Task<CountryDetailDTO> Handle(GetCountryDetailQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<CountryDetailDTO>(await _countryDetailService.FindCountryDetailAsync(request.Id, cancellationToken));
    }
}

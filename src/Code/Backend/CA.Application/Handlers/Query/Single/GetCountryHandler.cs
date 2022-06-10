using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetCountryHandler : IRequestHandler<GetCountryQuery, CountryDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICountryService _countryService;
        public GetCountryHandler(ICountryService countryService, IMapper mapper) =>
            (_countryService, _mapper) = (countryService, mapper);
        public async Task<CountryDTO> Handle(GetCountryQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<CountryDTO>(await _countryService.FindCountryAsync(request.Id, cancellationToken));
    }
}

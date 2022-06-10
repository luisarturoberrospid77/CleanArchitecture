using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class UpdateBrandHandler : IRequestHandler<UpdateBrandDTO, ApiResponse<UpdateBrandDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;
        public UpdateBrandHandler(IBrandService brandService, IMapper mapper) =>
            (_brandService, _mapper) = (brandService, mapper);
        public async Task<ApiResponse<UpdateBrandDTO>> Handle(UpdateBrandDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UpdateBrandDTO>(await _brandService.UpdateBrandAsync(request, cancellationToken));
            return new ApiResponse<UpdateBrandDTO>(entity, $"The brand with Id {entity.Id} was successfully updated.");
        }
    }
}

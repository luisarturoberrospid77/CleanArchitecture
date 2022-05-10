using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class UpdateBrandHandler : IRequestHandler<UpdateBrandDTO, ApiResponse<UpdateBrandDTO>>
    {
        private readonly IBrandService _brandService;
        public UpdateBrandHandler(IBrandService brandService) => _brandService = brandService;
        public async Task<ApiResponse<UpdateBrandDTO>> Handle(UpdateBrandDTO request, CancellationToken cancellationToken)
        {
            var entity = await _brandService.UpdateBrandAsync(request, cancellationToken);
            return new ApiResponse<UpdateBrandDTO>(entity, $"The brand with Id {entity.Id} was successfully updated.");
        }
    }
}

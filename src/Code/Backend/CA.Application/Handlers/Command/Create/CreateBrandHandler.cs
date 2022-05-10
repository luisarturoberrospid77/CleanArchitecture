using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class CreateBrandHandler : IRequestHandler<CreateBrandDTO, ApiResponse<CreateBrandDTO>>
    {
        private readonly IBrandService _brandService;
        public CreateBrandHandler(IBrandService brandService) => _brandService = brandService;
        public async Task<ApiResponse<CreateBrandDTO>> Handle(CreateBrandDTO request, CancellationToken cancellationToken)
        {
            var entity = await _brandService.InsertBrandAsync(request, cancellationToken);
            return new ApiResponse<CreateBrandDTO>(entity, $"The brand with name '{entity.Name}' was created successfully.");
        }
    }
}

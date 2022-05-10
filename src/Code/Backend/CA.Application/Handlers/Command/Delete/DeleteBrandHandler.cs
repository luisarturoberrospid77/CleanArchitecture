using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrandDTO, ApiResponse<DeleteBrandDTO>>
    {
        private readonly IBrandService _brandService;
        public DeleteBrandHandler(IBrandService brandService) => _brandService = brandService;
        public async Task<ApiResponse<DeleteBrandDTO>> Handle(DeleteBrandDTO request, CancellationToken cancellationToken)
        {
            var entity = await _brandService.DeleteBrandAsync(request, request.AutoSave, cancellationToken);
            return new ApiResponse<DeleteBrandDTO>(entity, $"The brand with Id {entity.Id} was successfully deleted.");
        }
    }
}

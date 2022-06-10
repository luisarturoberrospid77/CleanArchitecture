using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrandDTO, ApiResponse<DeleteBrandDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;
        public DeleteBrandHandler(IBrandService brandService, IMapper mapper) =>
            (_brandService, _mapper) = (brandService, mapper);
        public async Task<ApiResponse<DeleteBrandDTO>> Handle(DeleteBrandDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DeleteBrandDTO>(await _brandService.DeleteBrandAsync(request, request.AutoSave, cancellationToken));
            return new ApiResponse<DeleteBrandDTO>(entity, $"The brand with Id {entity.Id} was successfully deleted.");
        }
    }
}

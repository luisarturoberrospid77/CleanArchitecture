using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class CreateBrandHandler : IRequestHandler<CreateBrandDTO, ApiResponse<CreateBrandDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;
        public CreateBrandHandler(IBrandService brandService, IMapper mapper) =>
            (_brandService, _mapper) = (brandService, mapper);
        public async Task<ApiResponse<CreateBrandDTO>> Handle(CreateBrandDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateBrandDTO>(await _brandService.InsertBrandAsync(request, cancellationToken));
            return new ApiResponse<CreateBrandDTO>(entity, $"The brand with name '{entity.Name}' was created successfully.");
        }
    }
}

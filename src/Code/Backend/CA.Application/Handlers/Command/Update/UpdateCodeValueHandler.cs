using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class UpdateCodeValueHandler : IRequestHandler<UpdateCodeValueDTO, ApiResponse<UpdateCodeValueDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICodeValueService _codeValueService;
        public UpdateCodeValueHandler(ICodeValueService codeValueService, IMapper mapper) =>
            (_codeValueService, _mapper) = (codeValueService, mapper);
        public async Task<ApiResponse<UpdateCodeValueDTO>> Handle(UpdateCodeValueDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UpdateCodeValueDTO>(await _codeValueService.UpdateCodeValueAsync(request, cancellationToken));
            return new ApiResponse<UpdateCodeValueDTO>(entity, $"The code value with Id {entity.Id} was successfully updated.");
        }
    }
}

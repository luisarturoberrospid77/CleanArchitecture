using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class DeleteCodeValueHandler : IRequestHandler<DeleteCodeValueDTO, ApiResponse<DeleteCodeValueDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICodeValueService _codeValueService;
        public DeleteCodeValueHandler(ICodeValueService codeValueService, IMapper mapper) =>
            (_codeValueService, _mapper) = (codeValueService, mapper);
        public async Task<ApiResponse<DeleteCodeValueDTO>> Handle(DeleteCodeValueDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DeleteCodeValueDTO>(await _codeValueService.DeleteCodeValueAsync(request, request.AutoSave, cancellationToken));
            return new ApiResponse<DeleteCodeValueDTO>(entity, $"The code value with Id {entity.Id} was successfully deleted.");
        }
    }
}

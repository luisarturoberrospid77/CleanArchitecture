using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class CreateAssignmentOrderHandler : IRequestHandler<CreateAssignmentDTO, ApiResponse<CreateAssignmentDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IAssignmentOrderService _assignmentOrderService;
        public CreateAssignmentOrderHandler(IAssignmentOrderService assignmentOrderService, IMapper mapper) =>
            (_assignmentOrderService, _mapper) = (assignmentOrderService, mapper);
        public async Task<ApiResponse<CreateAssignmentDTO>> Handle(CreateAssignmentDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateAssignmentDTO>(await _assignmentOrderService.InsertAssigmentAsync(request, cancellationToken));
            return new ApiResponse<CreateAssignmentDTO>(entity, $"The order assignment for store id '{entity.StoreId}' was created successfully.");
        }
    }
}

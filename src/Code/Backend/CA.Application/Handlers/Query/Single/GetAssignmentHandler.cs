using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetAssignmentHandler : IRequestHandler<GetAssignmentQuery, AssignmentDTO>
    {
        private readonly IMapper _mapper;
        private readonly IAssignmentOrderService _assignmentOrderService;
        public GetAssignmentHandler(IAssignmentOrderService assignmentOrderService, IMapper mapper) =>
            (_assignmentOrderService, _mapper) = (assignmentOrderService, mapper);
        public async Task<AssignmentDTO> Handle(GetAssignmentQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<AssignmentDTO>(await _assignmentOrderService.FindAssigmentAsync(request.Id, cancellationToken));
    }
}

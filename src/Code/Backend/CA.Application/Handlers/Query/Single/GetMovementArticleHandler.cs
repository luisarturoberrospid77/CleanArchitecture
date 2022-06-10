using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetMovementArticleHandler : IRequestHandler<GetMovementArticleQuery, MovementArticleDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMovementArticleService _movementService;
        public GetMovementArticleHandler(IMovementArticleService movementService, IMapper mapper) =>
            (_movementService, _mapper) = (movementService, mapper);
        public async Task<MovementArticleDTO> Handle(GetMovementArticleQuery request, CancellationToken cancellationToken) => 
            _mapper.Map<MovementArticleDTO>(await _movementService.FindMovementArticleAsync(request.Id, cancellationToken));
    }
}

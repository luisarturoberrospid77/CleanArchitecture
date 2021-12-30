using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetMovementArticleHandler : IRequestHandler<GetMovementArticleQuery, MovementArticleDTO>
  {
    private readonly IMovementArticleService _movementService;
    public GetMovementArticleHandler(IMovementArticleService movementService) => _movementService = movementService;
    public async Task<MovementArticleDTO> Handle(GetMovementArticleQuery request, CancellationToken cancellationToken) =>
      await _movementService.FindMovementArticleAsync(request.Id, cancellationToken);
  }
}

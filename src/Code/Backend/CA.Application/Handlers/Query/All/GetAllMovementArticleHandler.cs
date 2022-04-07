using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllMovementArticleHandler : IRequestHandler<GetAllMovementArticleQuery, IEnumerable<MovementArticleDTO>>
  {
    private readonly IMovementArticleService _movementService;
    public GetAllMovementArticleHandler(IMovementArticleService movementService) => _movementService = movementService;
    public async Task<IEnumerable<MovementArticleDTO>> Handle(GetAllMovementArticleQuery request, CancellationToken cancellationToken) =>
      await _movementService.GetMovementArticlesAsync(cancellationToken);
  }
}

using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Repository;
using CA.Domain.Interfaces.Services;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
  public class MovementArticleService : RService<MovementArticleDTO, int,
                                                 MovementArticle, IMovementArticleRepository<PatosaDbContext>,
                                                 PatosaDbContext>, IMovementArticleService
  {
    public MovementArticleService(IMapper mapper,
                                  IUnitOfWork<PatosaDbContext> unitOfWork,
                                  IMovementArticleRepository<PatosaDbContext> movementArticleRepository) : base(mapper, unitOfWork, movementArticleRepository) { }
    public async Task<MovementArticleDTO> FindMovementArticleAsync(int id, CancellationToken cancellationToken = default) =>
      await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<MovementArticleDTO>> GetMovementArticlesAsync(CancellationToken cancellationToken = default) =>
      await GetAllAsync(cancellationToken);
  }
}

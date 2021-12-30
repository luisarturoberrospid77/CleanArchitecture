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
  public class MenuService : RService<MenuDTO, int,
                                      MenuSystem, IMenuRepository<PatosaDbContext>,
                                      PatosaDbContext>, IMenuService
  {
    public MenuService(IMapper mapper,
                       IUnitOfWork<PatosaDbContext> unitOfWork,
                       IMenuRepository<PatosaDbContext> menuRepository) : base(mapper, unitOfWork, menuRepository) { }
    public async Task<MenuDTO> FindMenuOptionAsync(int id, CancellationToken cancellationToken = default) =>
      await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<MenuDTO>> GetMenuOptionsAsync(CancellationToken cancellationToken = default) =>
      await GetAllAsync(cancellationToken);
  }
}

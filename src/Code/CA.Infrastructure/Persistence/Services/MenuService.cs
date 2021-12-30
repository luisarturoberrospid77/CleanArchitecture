using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using CA.Core.DTO;
using CA.Core.Entities;
using CA.Core.Interfaces.Base;
using CA.Core.Interfaces.Services;
using CA.Core.Interfaces.Repository;

using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Persistence.Services
{
  public class MenuService : RService<MenuDTO, int,
                                      MenuSystem, IMenuRepository<PatosaDbContext>, PatosaDbContext>, IMenuService
  {
    public MenuService(IMapper mapper, IUnitOfWork<PatosaDbContext> unitOfWork, IMenuRepository<PatosaDbContext> menuRepository) : base(menuRepository, unitOfWork, mapper) { }
    public async Task<MenuDTO> FindMenuOptionAsync(int id, CancellationToken cancellationToken = default) => await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<MenuDTO>> GetMenuOptions(CancellationToken cancellationToken = default) => await GetAll(cancellationToken);
  }
}

using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllMenuHandler : IRequestHandler<GetAllMenuQuery, IEnumerable<MenuDTO>>
  {
    private readonly IMenuService _menuService;
    public GetAllMenuHandler(IMenuService menuService) => _menuService = menuService;
    public async Task<IEnumerable<MenuDTO>> Handle(GetAllMenuQuery request, CancellationToken cancellationToken) =>
      await _menuService.GetMenuOptionsAsync(cancellationToken);
  }
}

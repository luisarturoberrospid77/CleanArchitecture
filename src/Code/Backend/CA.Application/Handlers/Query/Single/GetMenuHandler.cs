using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetMenuHandler : IRequestHandler<GetMenuQuery, MenuDTO>
  {
    private readonly IMenuService _menuService;
    public GetMenuHandler(IMenuService menuService) => _menuService = menuService;
    public async Task<MenuDTO> Handle(GetMenuQuery request, CancellationToken cancellationToken) =>
      await _menuService.FindMenuOptionAsync(request.Id, cancellationToken);
  }
}

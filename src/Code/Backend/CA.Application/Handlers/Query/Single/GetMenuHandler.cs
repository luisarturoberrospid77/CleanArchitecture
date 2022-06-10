using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetMenuHandler : IRequestHandler<GetMenuQuery, MenuDTO>
    {
        private readonly IMapper _mapper; 
        private readonly IMenuService _menuService; 
        public GetMenuHandler(IMenuService menuService, IMapper mapper) =>
            (_menuService, _mapper) = (menuService, mapper);
        public async Task<MenuDTO> Handle(GetMenuQuery request, CancellationToken cancellationToken) => 
            _mapper.Map<MenuDTO>(await _menuService.FindMenuOptionAsync(request.Id, cancellationToken));
    }
}

using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using CA.Core.DTO;
using CA.Core.Wrappers;
using CA.Core.Interfaces.Services;

namespace CA.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MenuController : ControllerBase
  {
    private readonly IMenuService _menuService;
    public MenuController(IMenuService menuService)
    {
      _menuService = menuService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMenuOptions()
    {
      var response = new ApiResponse<IEnumerable<MenuDTO>>(await _menuService.GetMenuOptions());
      return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMenuOption(int id)
    {
      MenuDTO _menuOptionDTO = await _menuService.FindMenuOptionAsync(id);

      if (_menuOptionDTO == null)
        return NotFound();

      var response = new ApiResponse<MenuDTO>(_menuOptionDTO);
      return Ok(response);
    }
  }
}

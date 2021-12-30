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
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
      var response = new ApiResponse<IEnumerable<CategoryDTO>>(await _categoryService.GetCategories());
      return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
      CategoryDTO _categoryDTO = await _categoryService.FindCategoryAsync(id);

      if (_categoryDTO == null)
        return NotFound();

      var response = new ApiResponse<CategoryDTO>(_categoryDTO);
      return Ok(response);
    }
  }
}

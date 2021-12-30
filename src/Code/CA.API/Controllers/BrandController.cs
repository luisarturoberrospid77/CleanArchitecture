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
  public class BrandController : ControllerBase
  {
    private readonly IBrandService _brandService;
    public BrandController(IBrandService brandService) => _brandService = brandService;

    [HttpGet]
    public async Task<IActionResult> GetBrands()
    {
      var response = new ApiResponse<IEnumerable<BrandDTO>>(await _brandService.GetBrands());
      return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrand(int id)
    {
      BrandDTO _brandDTO = await _brandService.FindBrandAsync(id);

      if (_brandDTO == null)
        return NotFound();

      var response = new ApiResponse<BrandDTO>(_brandDTO);
      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateBrandDTO obj)
    {
      obj = await _brandService.InsertBrandAsync(obj);
      var response = new ApiResponse<CreateBrandDTO>(obj);
      return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateBrandDTO obj)
    {
      obj = await _brandService.UpdateBrandAsync(obj);
      var response = new ApiResponse<UpdateBrandDTO>(obj);
      return Ok(response);
    }
  }
}

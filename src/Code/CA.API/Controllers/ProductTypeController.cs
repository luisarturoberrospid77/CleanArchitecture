using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CA.Core.Entities;
using CA.Core.Interfaces;

namespace CA.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductTypeController : ControllerBase
  {
    private readonly IProductTypeRepository _productTypeRepository;
    public ProductTypeController(IProductTypeRepository articleRepository) => _productTypeRepository = articleRepository;

    [HttpGet]
    public async Task<IActionResult> GetProductTypes()
    {
      var _productTypes = await _productTypeRepository.GetProductTypesAsync();
      return Ok(_productTypes);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductTypes(int id)
    {
      var _productType = await _productTypeRepository.GetProductTypeAsync(id);
      return Ok(_productType);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductType obj)
    {
      await _productTypeRepository.AddProductType(obj);
      return Ok(obj);
    }
  }
}

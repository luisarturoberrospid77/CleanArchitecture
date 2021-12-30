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
  public class SupplierController : ControllerBase
  {
    private readonly ISupplierService _supplierService;
    public SupplierController(ISupplierService supplierService)
    {
      _supplierService = supplierService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSuppliers()
    {
      var response = new ApiResponse<IEnumerable<SupplierDTO>>(await _supplierService.GetStores());
      return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SupplierDTO>> GetSupplier(int id)
    {
      SupplierDTO _storeDTO = await _supplierService.FindStoreAsync(id);

      if (_storeDTO == null)
        return NotFound();

      var response = new ApiResponse<SupplierDTO>(_storeDTO);
      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateSupplierDTO obj)
    {
      obj = await _supplierService.InsertStoreAsync(obj);
      var response = new ApiResponse<CreateSupplierDTO>(obj);
      return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateSupplierDTO obj)
    {
      obj = await _supplierService.UpdateSupplierAsync(obj);
      var response = new ApiResponse<UpdateSupplierDTO>(obj);
      return Ok(response);
    }
  }
}

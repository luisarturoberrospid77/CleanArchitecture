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
  public class StoreController : ControllerBase
  {
    private readonly IStoreService _storeService;

    public StoreController(IStoreService storeService)
    {
      _storeService = storeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStores()
    {
      var response = new ApiResponse<IEnumerable<StoreDTO>>(await _storeService.GetStores());
      return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStore(int id)
    {
      StoreDTO _storeDTO = await _storeService.FindStoreAsync(id);

      if (_storeDTO == null)
        return NotFound();

      var response = new ApiResponse<StoreDTO>(_storeDTO);
      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateStoreDTO obj)
    {
      obj = await _storeService.InsertStoreAsync(obj);
      var response = new ApiResponse<CreateStoreDTO>(obj);
      return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateStoreDTO obj)
    {
      obj = await _storeService.UpdateStoreAsync(obj);
      var response = new ApiResponse<UpdateStoreDTO>(obj);
      return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteStoreDTO obj)
    {
      await _storeService.DeleteStoreAsync(obj, obj.AutoSave);
      var response = new ApiResponse<DeleteStoreDTO>(obj);
      return Ok(response);
    }
  }
}

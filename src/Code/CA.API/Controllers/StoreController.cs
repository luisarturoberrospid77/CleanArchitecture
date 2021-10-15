using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CA.Core.Interfaces;

namespace CA.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StoreController : ControllerBase
  {
    private readonly IStoreRepository _storeRepository;

    public StoreController(IStoreRepository storeRepository) => _storeRepository = storeRepository;

    [HttpGet]
    public async Task<IActionResult> GetStores()
    {
      var _stores = await _storeRepository.GetStoresAsync();
      return Ok(_stores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStore(int id)
    {
      var _store = await _storeRepository.GetStoreAsync(id);
      return Ok(_store);
    }

  }
}

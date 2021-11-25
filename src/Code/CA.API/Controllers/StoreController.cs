using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using CA.Core.DTO;
using CA.Core.Entities;
using CA.Core.Interfaces;

namespace CA.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StoreController : ControllerBase
  {
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;

    public StoreController(IMapper mapper, IStoreRepository storeRepository)
    {
      _mapper = mapper; _storeRepository = storeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetStores()
    {
      var _stores = await _storeRepository.GetStoresAsync();
      var _storesDTO = _mapper.Map<IEnumerable<StoreDTO>>(_stores);
      return Ok(_storesDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStore(int id)
    {
      var _store = await _storeRepository.GetStoreAsync(id);
      var _storeDTO = _mapper.Map<StoreDTO>(_store);
      return Ok(_storeDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Post(StoreDTO obj)
    {
      var _store = _mapper.Map<Store>(obj);
      _store.Creationdate = DateTime.Now;
      await _storeRepository.AddStore(_store);
      return Ok(obj);
    }
  }
}

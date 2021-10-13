using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CA.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StoreController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetStores()
    {
      var _stores = new StoreRepository().GetStores();
      return Ok(_stores);
    }
  }
}

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
  public class ProductTypeController : ControllerBase
  {
    private readonly IProductTypeRepository _productTypeRepository;
    private readonly IMapper _mapper;

    public ProductTypeController(IMapper mapper, IProductTypeRepository productTypeRepository)
    {
      _mapper = mapper; _productTypeRepository = productTypeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductTypes()
    {
      var _productTypes = await _productTypeRepository.GetProductTypesAsync();
      var _productTypesDTO = _mapper.Map<IEnumerable<ProductTypeDTO>>(_productTypes);
      return Ok(_productTypesDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductTypes(int id)
    {
      var _productType = await _productTypeRepository.GetProductTypeAsync(id);
      var _productTypeDTO = _mapper.Map<ProductTypeDTO>(_productType);
      return Ok(_productTypeDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductTypeDTO obj)
    {
      var _productType = _mapper.Map<ProductType>(obj);
      _productType.Creationdate = DateTime.Now;
      await _productTypeRepository.AddProductType(_productType);
      return Ok(obj);
    }
  }
}

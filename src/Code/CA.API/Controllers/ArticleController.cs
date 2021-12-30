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
  public class ArticleController : ControllerBase
  {
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
      _articleService = articleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetArticles()
    {
      var response = new ApiResponse<IEnumerable<ArticleDTO>>(await _articleService.GetArticles());
      return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArticles(int id)
    {
      ArticleDTO _articleDTO = await _articleService.FindArticleAsync(id);

      if (_articleDTO == null)
        return NotFound();

      var response = new ApiResponse<ArticleDTO>(_articleDTO);
      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateArticleDTO obj)
    {
      obj = await _articleService.InsertArticleAsync(obj);
      var response = new ApiResponse<CreateArticleDTO>(obj);
      return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateArticleDTO obj)
    {
      obj = await _articleService.UpdateArticleAsync(obj);
      var response = new ApiResponse<UpdateArticleDTO>(obj);
      return Ok(response);
    }
  }
}

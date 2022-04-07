using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<CategoryDTO>>
  {
    private readonly ICategoryService _categoryService;
    public GetAllCategoryHandler(ICategoryService categoryService) => _categoryService = categoryService;
    public async Task<IEnumerable<CategoryDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken) =>
      await _categoryService.GetCategoriesAsync(cancellationToken);
  }
}

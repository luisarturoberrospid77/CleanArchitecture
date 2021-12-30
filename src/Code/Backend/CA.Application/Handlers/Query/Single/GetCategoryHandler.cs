using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, CategoryDTO>
  {
    private readonly ICategoryService _categoryService;
    public GetCategoryHandler(ICategoryService categoryService) => _categoryService = categoryService;
    public async Task<CategoryDTO> Handle(GetCategoryQuery request, CancellationToken cancellationToken) =>
      await _categoryService.FindCategoryAsync(request.Id, cancellationToken);
  }
}

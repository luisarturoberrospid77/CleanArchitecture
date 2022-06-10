using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, CategoryDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public GetCategoryHandler(ICategoryService categoryService, IMapper mapper) =>
            (_categoryService, _mapper) = (categoryService, mapper);
        public async Task<CategoryDTO> Handle(GetCategoryQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<CategoryDTO>(await _categoryService.FindCategoryAsync(request.Id, cancellationToken));
    }
}

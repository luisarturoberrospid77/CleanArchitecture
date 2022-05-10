using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class CreateArticleHandler : IRequestHandler<CreateArticleDTO, ApiResponse<CreateArticleDTO>>
    {
        private readonly IArticleService _articleService;
        public CreateArticleHandler(IArticleService articleService) => _articleService = articleService;
        public async Task<ApiResponse<CreateArticleDTO>> Handle(CreateArticleDTO request, CancellationToken cancellationToken)
        {
            var entity = await _articleService.InsertArticleAsync(request, cancellationToken);
            return new ApiResponse<CreateArticleDTO>(entity, $"The article with name '{entity.ShortName}' was created successfully.");
        }
    }
}

using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class UpdateArticleHandler : IRequestHandler<UpdateArticleDTO, ApiResponse<UpdateArticleDTO>>
    {
        private readonly IArticleService _articleService;
        public UpdateArticleHandler(IArticleService articleService) => _articleService = articleService;
        public async Task<ApiResponse<UpdateArticleDTO>> Handle(UpdateArticleDTO request, CancellationToken cancellationToken)
        {
            var entity = await _articleService.UpdateArticleAsync(request, cancellationToken);
            return new ApiResponse<UpdateArticleDTO>(entity, $"The article with Id {entity.Id} was successfully updated.");
        }
    }
}

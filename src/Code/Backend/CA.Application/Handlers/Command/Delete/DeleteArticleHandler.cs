using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class DeleteArticleHandler : IRequestHandler<DeleteArticleDTO, ApiResponse<DeleteArticleDTO>>
    {
        private readonly IArticleService _articleService;
        public DeleteArticleHandler(IArticleService articleService) => _articleService = articleService;
        public async Task<ApiResponse<DeleteArticleDTO>> Handle(DeleteArticleDTO request, CancellationToken cancellationToken)
        {
            var entity = await _articleService.DeleteArticleAsync(request, request.AutoSave, cancellationToken);
            return new ApiResponse<DeleteArticleDTO>(entity, $"The article with Id {entity.Id} was successfully deleted.");
        }
    }
}

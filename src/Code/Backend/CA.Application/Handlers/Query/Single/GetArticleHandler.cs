using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetArticleHandler : IRequestHandler<GetArticleQuery, ArticleDTO>
  {
    private readonly IArticleService _articleService;
    public GetArticleHandler(IArticleService articleService) => _articleService = articleService;
    public async Task<ArticleDTO> Handle(GetArticleQuery request, CancellationToken cancellationToken) =>
      await _articleService.FindArticleAsync(request.Id, cancellationToken);
  }
}

using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllArticleHandler : IRequestHandler<GetAllArticleQuery, IEnumerable<ArticleDTO>>
  {
    private readonly IArticleService _articleService;
    public GetAllArticleHandler(IArticleService articleService) => _articleService = articleService;
    public async Task<IEnumerable<ArticleDTO>> Handle(GetAllArticleQuery request, CancellationToken cancellationToken) =>
      await _articleService.GetArticlesAsync(cancellationToken);
  }
}

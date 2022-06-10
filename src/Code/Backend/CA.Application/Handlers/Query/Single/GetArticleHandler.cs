using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetArticleHandler : IRequestHandler<GetArticleQuery, ArticleDTO>
    {
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        public GetArticleHandler(IArticleService articleService, IMapper mapper) =>
            (_articleService, _mapper) = (articleService, mapper);
        public async Task<ArticleDTO> Handle(GetArticleQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<ArticleDTO>(await _articleService.FindArticleAsync(request.Id, cancellationToken));
    }
}

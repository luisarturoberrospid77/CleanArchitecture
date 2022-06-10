using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class CreateArticleHandler : IRequestHandler<CreateArticleDTO, ApiResponse<CreateArticleDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        public CreateArticleHandler(IArticleService articleService, IMapper mapper) =>
            (_articleService, _mapper) = (articleService, mapper);
        public async Task<ApiResponse<CreateArticleDTO>> Handle(CreateArticleDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateArticleDTO>(await _articleService.InsertArticleAsync(request, cancellationToken));
            return new ApiResponse<CreateArticleDTO>(entity, $"The article with name '{entity.ShortName}' was created successfully.");
        }
    }
}

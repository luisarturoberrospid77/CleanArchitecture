using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class UpdateArticleHandler : IRequestHandler<UpdateArticleDTO, ApiResponse<UpdateArticleDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        public UpdateArticleHandler(IArticleService articleService, IMapper mapper) =>
            (_articleService, _mapper) = (articleService, mapper);
        public async Task<ApiResponse<UpdateArticleDTO>> Handle(UpdateArticleDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UpdateArticleDTO>(await _articleService.UpdateArticleAsync(request, cancellationToken));
            return new ApiResponse<UpdateArticleDTO>(entity, $"The article with Id {entity.Id} was successfully updated.");
        }
    }
}

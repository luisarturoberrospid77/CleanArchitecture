using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Wrappers;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Command
{
    public class DeleteArticleHandler : IRequestHandler<DeleteArticleDTO, ApiResponse<DeleteArticleDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        public DeleteArticleHandler(IArticleService articleService, IMapper mapper) =>
            (_articleService, _mapper) = (articleService, mapper);
        public async Task<ApiResponse<DeleteArticleDTO>> Handle(DeleteArticleDTO request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DeleteArticleDTO>(await _articleService.DeleteArticleAsync(request, request.AutoSave, cancellationToken));
            return new ApiResponse<DeleteArticleDTO>(entity, $"The article with Id {entity.Id} was successfully deleted.");
        }
    }
}

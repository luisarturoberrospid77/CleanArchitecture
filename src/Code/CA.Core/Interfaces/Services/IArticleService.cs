using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

using CA.Core.DTO;

namespace CA.Core.Interfaces.Services
{
  public interface IArticleService
  {
    Task<ArticleDTO> FindArticleAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ArticleDTO>> GetArticles(CancellationToken cancellationToken = default);
    Task<CreateArticleDTO> InsertArticleAsync(CreateArticleDTO objDTO, CancellationToken cancellationToken = default);
    Task<UpdateArticleDTO> UpdateArticleAsync(UpdateArticleDTO objDTO, CancellationToken cancellationToken = default);
    Task<DeleteArticleDTO> DeleteArticleAsync(DeleteArticleDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
  }
}

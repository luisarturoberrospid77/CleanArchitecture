using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using CA.Core.DTO;
using CA.Core.Entities;
using CA.Core.Interfaces.Base;
using CA.Core.Interfaces.Services;
using CA.Core.Interfaces.Repository;

using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Persistence.Services
{
  public class ArticleService : CRUDService<ArticleDTO, CreateArticleDTO, UpdateArticleDTO, DeleteArticleDTO, int,
                                            Article, IArticleRepository<PatosaDbContext>, PatosaDbContext>, IArticleService
  {
    public ArticleService(IMapper mapper, IUnitOfWork<PatosaDbContext> unitOfWork, IArticleRepository<PatosaDbContext> articleRepository) : 
      base(articleRepository, unitOfWork, mapper) { }
    public async Task<ArticleDTO> FindArticleAsync(int id, CancellationToken cancellationToken = default) => 
      await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<ArticleDTO>> GetArticles(CancellationToken cancellationToken = default) => 
      await GetAll(cancellationToken);
    public async Task<CreateArticleDTO> InsertArticleAsync(CreateArticleDTO objDTO, CancellationToken cancellationToken = default) => 
      await InsertAsync(objDTO, cancellationToken);
    public async Task<UpdateArticleDTO> UpdateArticleAsync(UpdateArticleDTO objDTO, CancellationToken cancellationToken = default) =>
      await UpdateAsync(objDTO, cancellationToken);
    public async Task<DeleteArticleDTO> DeleteArticleAsync(DeleteArticleDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default) =>
      await DeleteAsync(objDTO, autoSave, cancellationToken);
  }
}

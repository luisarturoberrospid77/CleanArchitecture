using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.DTO.Base;
using CA.Domain.Entities;
using CA.Domain.Exceptions;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Repository;
using CA.Domain.Interfaces.Services;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
  public class ArticleService : CRUDService<ArticleDTO, CommandDTO, int,
                                            Article, IArticleRepository<PatosaDbContext>,
                                            PatosaDbContext>, IArticleService
  {
    public ArticleService(IMapper mapper,
                          IUnitOfWork<PatosaDbContext> unitOfWork,
                          IArticleRepository<PatosaDbContext> articleRepository) : base(mapper, articleRepository, unitOfWork) { }
    public async Task<ArticleDTO> FindArticleAsync(int id, CancellationToken cancellationToken = default) =>
      await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<ArticleDTO>> GetArticlesAsync(CancellationToken cancellationToken = default) =>
      await GetAllAsync(cancellationToken);
    public async Task<CreateArticleDTO> InsertArticleAsync(CreateArticleDTO objDTO, CancellationToken cancellationToken = default)
    {
      var ifExists = await FilterAsync(u => u.ShortName == objDTO.ShortName && u.IsDeleted == false);

      if (ifExists.Count() > 0)
        throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.ShortName);
      else
        return Mapper.Map<CreateArticleDTO>(await InsertAsync(objDTO, cancellationToken));
    }
    public async Task<UpdateArticleDTO> UpdateArticleAsync(UpdateArticleDTO objDTO, CancellationToken cancellationToken = default)
    {
      var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

      if (ifExists == null)
        throw new EntityNotFoundException(objDTO.Id.ToString());
      else
        return Mapper.Map<UpdateArticleDTO>(await UpdateAsync(objDTO, cancellationToken));
    }
    public async Task<DeleteArticleDTO> DeleteArticleAsync(DeleteArticleDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
    {
      var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

      if (ifExists == null | ifExists.Count() == 0)
        throw new EntityNotFoundException(objDTO.Id.ToString());
      else
        return Mapper.Map<DeleteArticleDTO>(await DeleteAsync(objDTO, autoSave, cancellationToken));
    }
  }
}

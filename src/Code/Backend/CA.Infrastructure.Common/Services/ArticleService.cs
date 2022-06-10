using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.DTO.Base;
using CA.Domain.Entities;
using CA.Domain.Exceptions;
using CA.Domain.Entities.Base;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Services;
using CA.Domain.Interfaces.Management;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
    public class ArticleService : CRUDService<CommandDTO, int,
                                              Article, IArticleRepository<PatosaDbContext>,
                                              PatosaDbContext>, IArticleService
    {
        private readonly IDataShapeHelper<ArticleDTO> _dataShaperHelper;

        public ArticleService(IMapper mapper,
                              IUnitOfWork<PatosaDbContext> unitOfWork,
                              IArticleRepository<PatosaDbContext> articleRepository,
                              IDataShapeHelper<ArticleDTO> dataShapeHelper) : base(mapper, articleRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<Article> DeleteArticleAsync(DeleteArticleDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false, cancellationToken);

            if (ifExists == null)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return await DeleteAsync(objDTO, false, cancellationToken);
        }
        public async Task<Article> FindArticleAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetArticlesAsync(Expression<Func<Article, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<ArticleDTO>>(await GetAllAsync(predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedArticlesAsync(int pageNumber, int pageSize, Expression<Func<Article, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) => (predicate == null) ?
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<ArticleDTO>>(await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken)), fields) :
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<ArticleDTO>>(await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<Article> InsertArticleAsync(CreateArticleDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.ShortName == objDTO.ShortName && u.IsDeleted == false, cancellationToken);

            if (ifExists.Any())
                throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.ShortName);
            else
                return await InsertAsync(objDTO, cancellationToken);
        }
        public async Task<Article> UpdateArticleAsync(UpdateArticleDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false, cancellationToken);

            if (ifExists == null)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return await UpdateAsync(objDTO, cancellationToken);
        }
    }
}

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;
using Microsoft.Extensions.Options;

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
    public class ArticleService : CRUDService<ArticleDTO, CommandDTO, int,
                                              Article, IArticleRepository<PatosaDbContext>,
                                              PatosaDbContext>, IArticleService
    {
        private readonly IDataShapeHelper<ArticleDTO> _dataShaperHelper;

        public ArticleService(IMapper mapper,
                              IUnitOfWork<PatosaDbContext> unitOfWork,
                              IArticleRepository<PatosaDbContext> articleRepository,
                              IDataShapeHelper<ArticleDTO> dataShapeHelper) : base(mapper, articleRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<ArticleDTO> FindArticleAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetArticlesAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null) =>
            await _dataShaperHelper.ShapeDataAsync(await GetAllAsync(cancellationToken, fields, orderBy), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedArticlesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, Expression<Func<Article, bool>> predicate = null, string fields = null, string orderBy = null) =>
            (predicate == null) ? await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, cancellationToken, fields, orderBy), fields) :
                                    await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, fields, orderBy), fields);
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

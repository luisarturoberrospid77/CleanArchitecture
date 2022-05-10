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
    public class CodeNameSpaceService : CRUDService<CodeNameSpaceDTO, CommandDTO, int,
                                                    CodeNamespace, ICodeNameSpaceRepository<PatosaDbContext>,
                                                    PatosaDbContext>, ICodeNameSpaceService
    {
        private readonly IDataShapeHelper<CodeNameSpaceDTO> _dataShaperHelper;

        public CodeNameSpaceService(IMapper mapper,
                                    IUnitOfWork<PatosaDbContext> unitOfWork,
                                    ICodeNameSpaceRepository<PatosaDbContext> codeNameSpaceRepository,
                                    IDataShapeHelper<CodeNameSpaceDTO> dataShapeHelper) : base(mapper, codeNameSpaceRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<CodeNameSpaceDTO> FindCodeNameSpaceAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetCodeNameSpacesAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null) =>
            await _dataShaperHelper.ShapeDataAsync(await GetAllAsync(cancellationToken, fields, orderBy), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedCodeNameSpacesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, Expression<Func<CodeNamespace, bool>> predicate = null, string fields = null, string orderBy = null) =>
            (predicate == null) ? await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, cancellationToken, fields, orderBy), fields) :
                                    await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, fields, orderBy), fields);
        public async Task<CreateCodeNameSpaceDTO> InsertCodeNameSpaceAsync(CreateCodeNameSpaceDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Name == objDTO.Name && u.IsDeleted == false);

            if (ifExists.Count() > 0)
                throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.Name);
            else
                return Mapper.Map<CreateCodeNameSpaceDTO>(await InsertAsync(objDTO, cancellationToken));
        }
        public async Task<UpdateCodeNameSpaceDTO> UpdateCodeNameSpaceAsync(UpdateCodeNameSpaceDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

            if (ifExists == null)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return Mapper.Map<UpdateCodeNameSpaceDTO>(await UpdateAsync(objDTO, cancellationToken));
        }
        public async Task<DeleteCodeNameSpaceDTO> DeleteCodeNameSpaceAsync(DeleteCodeNameSpaceDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

            if (ifExists == null | ifExists.Count() == 0)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return Mapper.Map<DeleteCodeNameSpaceDTO>(await DeleteAsync(objDTO, autoSave, cancellationToken));
        }
    }
}

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
    public class CodeValueService : CRUDService<CodeValueDTO, CommandDTO, int,
                                                CodeValue, ICodeValueRepository<PatosaDbContext>,
                                                PatosaDbContext>, ICodeValueService
    {
        private readonly IDataShapeHelper<CodeValueDTO> _dataShaperHelper;

        public CodeValueService(IMapper mapper,
                                IUnitOfWork<PatosaDbContext> unitOfWork,
                                ICodeValueRepository<PatosaDbContext> codeValueRepository,
                                IDataShapeHelper<CodeValueDTO> dataShapeHelper) : base(mapper, codeValueRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<CodeValueDTO> FindCodeValueAsync(int id, CancellationToken cancellationToken = default) =>
            await GetSingleAsync(u => u.Id == id & u.IsDeleted == false, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetCodeValuesAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null) =>
            await _dataShaperHelper.ShapeDataAsync(await GetAllAsync(cancellationToken, fields, orderBy), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedCodeValuesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, Expression<Func<CodeValue, bool>> predicate = null, string fields = null, string orderBy = null) =>
            (predicate == null) ? await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, cancellationToken, fields, orderBy), fields) :
                                    await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, fields, orderBy), fields);
        public async Task<CreateCodeValueDTO> InsertCodeValueAsync(CreateCodeValueDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Description == objDTO.Description && u.IsDeleted == false, cancellationToken);

            if (ifExists.Count() > 0)
                throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.Description);
            else
                return Mapper.Map<CreateCodeValueDTO>(await InsertAsync(objDTO, cancellationToken));
        }
        public async Task<UpdateCodeValueDTO> UpdateCodeValueAsync(UpdateCodeValueDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false, cancellationToken);

            if (ifExists == null)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return Mapper.Map<UpdateCodeValueDTO>(await UpdateAsync(objDTO, cancellationToken));
        }
        public async Task<DeleteCodeValueDTO> DeleteCodeValueAsync(DeleteCodeValueDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false, cancellationToken);

            if (ifExists == null | ifExists.Count() == 0)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return Mapper.Map<DeleteCodeValueDTO>(await DeleteAsync(objDTO, autoSave, cancellationToken));
        }
    }
}

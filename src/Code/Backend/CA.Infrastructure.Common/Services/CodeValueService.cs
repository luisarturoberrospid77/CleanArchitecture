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
    public class CodeValueService : CRUDService<CommandDTO, int,
                                                CodeValue, ICodeValueRepository<PatosaDbContext>,
                                                PatosaDbContext>, ICodeValueService
    {
        private readonly IDataShapeHelper<CodeValueDTO> _dataShaperHelper;

        public CodeValueService(IMapper mapper,
                                IUnitOfWork<PatosaDbContext> unitOfWork,
                                ICodeValueRepository<PatosaDbContext> codeValueRepository,
                                IDataShapeHelper<CodeValueDTO> dataShapeHelper) : base(mapper, codeValueRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<CodeValue> DeleteCodeValueAsync(DeleteCodeValueDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false, cancellationToken);

            if (ifExists == null)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return await DeleteAsync(objDTO, false, cancellationToken);
        }
        public async Task<CodeValue> FindCodeValueAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetCodeValuesAsync(Expression<Func<CodeValue, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<CodeValueDTO>>(await GetAllAsync(predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedCodeValuesAsync(int pageNumber, int pageSize, Expression<Func<CodeValue, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) => (predicate == null) ?
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<CodeValueDTO>>(await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken)), fields) :
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<CodeValueDTO>>(await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<CodeValue> InsertCodeValueAsync(CreateCodeValueDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Description == objDTO.Description && u.IsDeleted == false, cancellationToken);

            if (ifExists.Any())
                throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.Description);
            else
                return await InsertAsync(objDTO, cancellationToken);
        }
        public async Task<CodeValue> UpdateCodeValueAsync(UpdateCodeValueDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false, cancellationToken);

            if (ifExists == null)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return await UpdateAsync(objDTO, cancellationToken);
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Entities.Base;

namespace CA.Domain.Interfaces.Services
{
    public interface ICodeValueService
    {
        public int RowCount { get; }
        Task<CodeValueDTO> FindCodeValueAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetCodeValuesAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedCodeValuesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, Expression<Func<CodeValue, bool>> predicate = null, string fields = null, string orderBy = null);
        Task<CreateCodeValueDTO> InsertCodeValueAsync(CreateCodeValueDTO objDTO, CancellationToken cancellationToken = default);
        Task<UpdateCodeValueDTO> UpdateCodeValueAsync(UpdateCodeValueDTO objDTO, CancellationToken cancellationToken = default);
        Task<DeleteCodeValueDTO> DeleteCodeValueAsync(DeleteCodeValueDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

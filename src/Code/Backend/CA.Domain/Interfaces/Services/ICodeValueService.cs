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
        Task<CodeValue> FindCodeValueAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetCodeValuesAsync(Expression<Func<CodeValue, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedCodeValuesAsync(int pageNumber, int pageSize, Expression<Func<CodeValue, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<CodeValue> InsertCodeValueAsync(CreateCodeValueDTO objDTO, CancellationToken cancellationToken = default);
        Task<CodeValue> UpdateCodeValueAsync(UpdateCodeValueDTO objDTO, CancellationToken cancellationToken = default);
        Task<CodeValue> DeleteCodeValueAsync(DeleteCodeValueDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

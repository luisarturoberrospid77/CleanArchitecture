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
    public interface ICodeNameSpaceService
    {
        public int RowCount { get; }
        Task<CodeNamespace> FindCodeNameSpaceAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetCodeNameSpacesAsync(Expression<Func<CodeNamespace, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedCodeNameSpacesAsync(int pageNumber, int pageSize, Expression<Func<CodeNamespace, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<CodeNamespace> InsertCodeNameSpaceAsync(CreateCodeNameSpaceDTO objDTO, CancellationToken cancellationToken = default);
        Task<CodeNamespace> UpdateCodeNameSpaceAsync(UpdateCodeNameSpaceDTO objDTO, CancellationToken cancellationToken = default);
        Task<CodeNamespace> DeleteCodeNameSpaceAsync(DeleteCodeNameSpaceDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

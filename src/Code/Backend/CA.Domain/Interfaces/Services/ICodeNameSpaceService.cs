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
        Task<CodeNameSpaceDTO> FindCodeNameSpaceAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetCodeNameSpacesAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedCodeNameSpacesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, Expression<Func<CodeNamespace, bool>> predicate = null, string fields = null, string orderBy = null);
        Task<CreateCodeNameSpaceDTO> InsertCodeNameSpaceAsync(CreateCodeNameSpaceDTO objDTO, CancellationToken cancellationToken = default);
        Task<UpdateCodeNameSpaceDTO> UpdateCodeNameSpaceAsync(UpdateCodeNameSpaceDTO objDTO, CancellationToken cancellationToken = default);
        Task<DeleteCodeNameSpaceDTO> DeleteCodeNameSpaceAsync(DeleteCodeNameSpaceDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

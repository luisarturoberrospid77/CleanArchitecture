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
    public interface IAssignmentOrderService
    {
        public int RowCount { get; }
        Task<Assignment> FindAssigmentAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedAssignmentOrderAsync(int pageNumber, int pageSize, Expression<Func<Assignment, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<Assignment> InsertAssigmentAsync(CreateAssignmentDTO objDTO, CancellationToken cancellationToken = default);
    }
}

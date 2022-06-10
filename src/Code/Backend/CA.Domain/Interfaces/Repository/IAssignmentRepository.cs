using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;

namespace CA.Domain.Interfaces.Repository
{
    public interface IAssignmentRepository<TContext> : IBaseRepository<Assignment, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<Assignment>> GetAssignmentAsync(CancellationToken cancellationToken = default);
        Task<Assignment> GetAssignmentAsync(int id, CancellationToken cancellationToken = default);
        Task<Assignment> SingleAssignmentAsync(Expression<Func<Assignment, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<Assignment>> FilterAssignmentAsync(Expression<Func<Assignment, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddAssignmentAsync(Assignment obj, CancellationToken cancellationToken = default);
        Task AddRangeAssignmentAsync(IEnumerable<Assignment> obj, CancellationToken cancellationToken = default);
        void UpdateAssignment(Assignment obj);
        void DeleteAssignment(Assignment obj);
    }
}

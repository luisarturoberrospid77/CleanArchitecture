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
    public interface IAssignmentDetailRepository<TContext> : IBaseRepository<AssignmentDetail, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<AssignmentDetail>> GetAssignmentDetailAsync(CancellationToken cancellationToken = default);
        Task<AssignmentDetail> GetAssignmentDetailAsync(int id, CancellationToken cancellationToken = default);
        Task<AssignmentDetail> SingleAssignmentDetailAsync(Expression<Func<AssignmentDetail, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<AssignmentDetail>> FilterAssignmentDetailAsync(Expression<Func<AssignmentDetail, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddAssignmentDetailAsync(AssignmentDetail obj, CancellationToken cancellationToken = default);
        Task AddRangeAssignmentDetailAsync(IEnumerable<AssignmentDetail> obj, CancellationToken cancellationToken = default);
        void UpdateAssignmentDetail(AssignmentDetail obj);
        void DeleteAssignmentDetail(AssignmentDetail obj);
    }
}

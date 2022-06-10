using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Repository.Base;

namespace CA.Infrastructure.Common.Repositories
{
    public class AssignmentRepository : BaseRepository<Assignment, int, PatosaDbContext>,
                                        IAssignmentRepository<PatosaDbContext>
    {
        public AssignmentRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
        public async Task AddAssignmentAsync(Assignment obj, CancellationToken cancellationToken = default) =>
            await AddAsync(obj, cancellationToken);
        public async Task AddRangeAssignmentAsync(IEnumerable<Assignment> obj, CancellationToken cancellationToken = default) =>
            await AddRangeAsync(obj, cancellationToken);
        public void DeleteAssignment(Assignment obj) => Delete(obj);
        public async Task<IEnumerable<Assignment>> FilterAssignmentAsync(Expression<Func<Assignment, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterAsync(predicate, cancellationToken);
        public async Task<IEnumerable<Assignment>> GetAssignmentAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
        public async Task<Assignment> GetAssignmentAsync(int id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken);
        public async Task<Assignment> SingleAssignmentAsync(Expression<Func<Assignment, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterSingleAsync(predicate, cancellationToken);
        public void UpdateAssignment(Assignment obj) => Update(obj);
    }
}

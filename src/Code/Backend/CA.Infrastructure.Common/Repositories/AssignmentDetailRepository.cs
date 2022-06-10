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
    public class AssignmentDetailRepository : BaseRepository<AssignmentDetail, int, PatosaDbContext>,
                                                IAssignmentDetailRepository<PatosaDbContext>
    {
        public AssignmentDetailRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
        public async Task AddAssignmentDetailAsync(AssignmentDetail obj, CancellationToken cancellationToken = default) =>
            await AddAsync(obj, cancellationToken);
        public async Task AddRangeAssignmentDetailAsync(IEnumerable<AssignmentDetail> obj, CancellationToken cancellationToken = default) =>
            await AddRangeAsync(obj, cancellationToken);
        public void DeleteAssignmentDetail(AssignmentDetail obj) => Delete(obj);
        public async Task<IEnumerable<AssignmentDetail>> FilterAssignmentDetailAsync(Expression<Func<AssignmentDetail, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterAsync(predicate, cancellationToken);
        public async Task<IEnumerable<AssignmentDetail>> GetAssignmentDetailAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
        public async Task<AssignmentDetail> GetAssignmentDetailAsync(int id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken);
        public async Task<AssignmentDetail> SingleAssignmentDetailAsync(Expression<Func<AssignmentDetail, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterSingleAsync(predicate, cancellationToken);
        public void UpdateAssignmentDetail(AssignmentDetail obj) => Update(obj);
    }
}

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
    public class CodeValueRepository : BaseRepository<CodeValue, int, PatosaDbContext>,
                                            ICodeValueRepository<PatosaDbContext>
    {
        public CodeValueRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
        public async Task AddCodeValueAsync(CodeValue obj, CancellationToken cancellationToken = default) =>
            await AddAsync(obj, cancellationToken);
        public async Task AddRangeCodeValueAsync(IEnumerable<CodeValue> obj, CancellationToken cancellationToken = default) =>
            await AddRangeAsync(obj, cancellationToken);
        public void DeleteCodeValue(CodeValue obj) => Delete(obj);
        public async Task<IEnumerable<CodeValue>> FilterCodeValueAsync(Expression<Func<CodeValue, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterAsync(predicate, cancellationToken);
        public async Task<IEnumerable<CodeValue>> GetCodeValuesAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
        public async Task<CodeValue> GetCodeValueAsync(int id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken);
        public async Task<IEnumerable<CodeValue>> GetPagedCodeValuesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default) =>
            await GetPagedAsync(pageNumber, pageSize, cancellationToken);
        public async Task<CodeValue> SingleCodeValueAsync(Expression<Func<CodeValue, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterSingleAsync(predicate, cancellationToken);
        public void UpdateCodeValue(CodeValue obj) => Update(obj);
    }
}

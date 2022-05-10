using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using CA.Domain.Interfaces.Base;

namespace CA.Infrastructure.UnitOfWork.Base
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : DbContext, new()
    {
        private TContext _dbContext;
        private IDbContextTransaction _objTran;
        private readonly IDbFactory<TContext> _dbFactory;
        public UnitOfWork(IDbFactory<TContext> dbFactory) { _dbFactory = dbFactory; }
        public TContext DbContext { get { return _dbContext ??= _dbFactory.Init(); } }

        #region "CreateTransaction"
        public void CreateTransaction() => _objTran = DbContext.Database.BeginTransaction();
        public async Task CreateTransactionAsync() => _objTran = await DbContext.Database.BeginTransactionAsync();
        public async Task CreateTransactionAsync(CancellationToken cancellationToken = default) =>
            _objTran = await DbContext.Database.BeginTransactionAsync(cancellationToken);
        #endregion "CreateTransaction"

        #region "Commit"
        public void Commit() => DbContext.SaveChanges();
        public async Task CommitAsync(CancellationToken cancellationToken = default) =>
            await DbContext.SaveChangesAsync(cancellationToken);
        public async Task CommitAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) =>
            await DbContext.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        #endregion "Commit"

        #region "Rollback"
        public void Rollback() { _objTran.Rollback(); _objTran.Dispose(); }
        public async Task RollbackAsync() { await _objTran.RollbackAsync(); await _objTran.DisposeAsync(); }
        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _objTran.RollbackAsync(cancellationToken); await _objTran.DisposeAsync();
        }
        #endregion "Rollback"
    }
}

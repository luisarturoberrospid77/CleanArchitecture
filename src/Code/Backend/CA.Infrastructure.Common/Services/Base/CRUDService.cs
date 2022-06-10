using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;

using AutoMapper;
using Ardalis.GuardClauses;

using Microsoft.EntityFrameworkCore;

using CA.Domain.Exceptions;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Management;
using CA.Domain.Interfaces.Services.Base;

namespace CA.Infrastructure.Persistence.Services.Base
{
    public abstract class CRUDService<TCommandDTO, TKey, TEntity, TRepoAll, TContext> :
        ICRUDService<TCommandDTO, TKey, TEntity, TRepoAll, TContext>
        where TEntity : class, IEntityBase<TKey>
        where TRepoAll : IBaseRepository<TEntity, TContext>
        where TContext : DbContext, new()
    {
        internal int _iCount;
        internal readonly IMapper _mapper;
        internal readonly TRepoAll _repository;
        internal readonly IUnitOfWork<TContext> _unitOfWork;
        public int RowCount => _iCount;
        protected IMapper Mapper => _mapper;
        protected TRepoAll Repository => _repository;
        protected IUnitOfWork<TContext> UnitOfWork => _unitOfWork;
        public CRUDService(IMapper mapper, 
                           TRepoAll repository,
                           IUnitOfWork<TContext> unitOfWork)
        {
            _repository = Guard.Against.Null(repository, nameof(repository));
            _mapper = Guard.Against.Null(mapper, nameof(mapper));
            _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
        }
        public async Task<TEntity> UpdateAsync(TCommandDTO objDTO, CancellationToken cancellationToken = default)
        {
            TEntity updatedEntity = await _repository.GetByIdAsync(Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id), cancellationToken);

            if (updatedEntity == null)
                throw new EntityNotFoundException(typeof(TEntity), Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id));

            /* Mapper.Map(objDTO, updatedEntity); */
            _repository.Update(updatedEntity);

            /* Apply changes... */
            await _unitOfWork.CommitAsync(cancellationToken);
            return updatedEntity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entityObj, CancellationToken cancellationToken = default)
        {
            TEntity updatedEntity = await _repository.GetByIdAsync(Convert.ToInt32(entityObj.Id), cancellationToken);

            if (updatedEntity == null)
                throw new EntityNotFoundException(typeof(TEntity), Convert.ToInt32(entityObj.Id));

            /* Mapper.Map(objDTO, updatedEntity); */
            _repository.Update(updatedEntity);

            /* Apply changes... */
            await _unitOfWork.CommitAsync(cancellationToken);
            return updatedEntity;
        }
        public async Task<TEntity> InsertAsync(TCommandDTO objDTO, CancellationToken cancellationToken = default)
        {
            TEntity addEntity = Mapper.Map<TEntity>(objDTO);
            await _repository.AddAsync(addEntity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return addEntity;
        }
        public async Task<TEntity> InsertAsync(TEntity entityObj, CancellationToken cancellationToken = default)
        {
            await _repository.AddAsync(entityObj, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return entityObj;
        }
        public async Task<TEntity> DeleteAsync(TCommandDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            TEntity deletedEntity = await _repository.GetByIdAsync(Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id), cancellationToken);

            if (deletedEntity == null)
                throw new EntityNotFoundException(typeof(TEntity), Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id));

            if (autoSave)
                _repository.Update(deletedEntity);
            else
                _repository.Delete(deletedEntity);

            /* Apply changes... */
            await _unitOfWork.CommitAsync(cancellationToken);
            return deletedEntity;
        }
        public async Task<TEntity> DeleteAsync(TEntity entityObj, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            TEntity deletedEntity = await _repository.GetByIdAsync(Convert.ToInt32(entityObj.Id), cancellationToken);

            if (deletedEntity == null)
                throw new EntityNotFoundException(typeof(TEntity), Convert.ToInt32(entityObj.Id));

            if (autoSave)
                _repository.Update(deletedEntity);
            else
                _repository.Delete(deletedEntity);

            /* Apply changes... */
            await _unitOfWork.CommitAsync(cancellationToken);
            return deletedEntity;
        }
        public async Task<TEntity> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            TEntity getEntity = await _repository.GetByIdAsync(id, cancellationToken);

            if (getEntity != null)
                return getEntity;
            else
                throw new EntityNotFoundException(typeof(TEntity), id);
        }
        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            TEntity getEntity = await _repository.FilterSingleAsync(predicate, cancellationToken);

            if (getEntity != null)
                return getEntity;
            else
                throw new EntityNotFoundException(typeof(TEntity));
        }
        public async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repository.FilterAsync(predicate, cancellationToken);
            return list;
        }
        public async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate, string orderBy = null, CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repository.FilterAsync(predicate, orderBy, cancellationToken);
            return list;
        }
        public async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate, string fields = null, string orderBy = null, CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repository.FilterAsync(predicate, orderBy, cancellationToken);

            /* Limit query fields. */
            if (!string.IsNullOrWhiteSpace(fields))
                list = list.AsQueryable().Select<TEntity>($"new({fields})");

            return list;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(string fields = null, string orderBy = null, CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repository.AllAsync(orderBy, cancellationToken);

            /* Limit query fields. */
            if (!string.IsNullOrWhiteSpace(fields))
                list = list.AsQueryable().Select<TEntity>($"new({fields})");

            return list;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, string fields = null, string orderBy = null, CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> list = await _repository.AllAsync(predicate, orderBy, cancellationToken);

            /* Limit query fields. */
            if (!string.IsNullOrWhiteSpace(fields))
                list = list.AsQueryable().Select<TEntity>($"new({fields})");

            return list;
        }
        public async Task<IEnumerable<TEntity>> GetPagedAsync(int pageNumber, int pageSize, string fields = null, string orderBy = null, CancellationToken cancellationToken = default)
        {
            _iCount = _repository.GetCount();

            if (pageNumber < 1 || (pageNumber > ((int)Math.Ceiling(_iCount / (double)pageSize))))
                throw new PageRowIndexNotFound(pageNumber);

            if (pageSize < 10)
                throw new PageRowMinimumException(pageSize);

            if (pageSize > 50)
                throw new PageRowMaximumException(pageSize);

            IEnumerable<TEntity> list = await _repository.GetPagedAsync(pageNumber, pageSize, orderBy, cancellationToken);

            /* Limit query fields. */
            if (!string.IsNullOrWhiteSpace(fields))
                list = list.AsQueryable().Select<TEntity>($"new({fields})");

            return list;
        }
        public async Task<IEnumerable<TEntity>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, string fields = null, string orderBy = null, CancellationToken cancellationToken = default)
        {
            _iCount = _repository.GetCount(predicate);

            if (pageNumber < 1 || (pageNumber > ((int)Math.Ceiling(_iCount / (double)pageSize))))
                throw new PageRowIndexNotFound(pageNumber);

            if (pageSize < 10)
                throw new PageRowMinimumException(pageSize);

            if (pageSize > 50)
                throw new PageRowMaximumException(pageSize);

            IEnumerable<TEntity> list = await _repository.GetPagedAsync(pageNumber, pageSize, predicate, orderBy, cancellationToken);

            /* Limit query fields. */
            if (!string.IsNullOrWhiteSpace(fields))
                list = list.AsQueryable().Select<TEntity>($"new({fields})");

            return list;
        }
    }
}

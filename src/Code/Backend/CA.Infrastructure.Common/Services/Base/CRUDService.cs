using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
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
  public abstract class CRUDService<TQueryDTO, TCommandDTO, TKey, TEntity, TRepoAll, TContext> :
    ICRUDService<TQueryDTO, TCommandDTO, TKey, TEntity, TRepoAll, TContext>
      where TEntity : class, IEntityBase<TKey>
      where TRepoAll : IBaseRepository<TEntity, TContext>
      where TContext : DbContext, new()
  {
    internal readonly IMapper _mapper;
    internal readonly TRepoAll _repository;
    internal readonly IUnitOfWork<TContext> _unitOfWork;

    protected IMapper Mapper => _mapper;
    protected TRepoAll Repository => _repository;
    protected IUnitOfWork<TContext> UnitOfWork => _unitOfWork;
    public CRUDService(IMapper mapper, TRepoAll repository, IUnitOfWork<TContext> unitOfWork)
    {
      _repository = Guard.Against.Null(repository, nameof(repository));
      _mapper = Guard.Against.Null(mapper, nameof(mapper));
      _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
    }
    public async Task<TQueryDTO> DeleteAsync(TCommandDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
    {
      TEntity deletedEntity = await _repository.GetByIdAsync(Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id), cancellationToken);

      if (deletedEntity == null)
        throw new EntityNotFoundException(typeof(TEntity), Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id));

      if (autoSave)
      {
        Mapper.Map(objDTO, deletedEntity);
        _repository.Update(deletedEntity);
      }
      else
        _repository.Delete(deletedEntity);

      await _unitOfWork.CommitAsync(cancellationToken);
      return Mapper.Map<TQueryDTO>(deletedEntity);
    }
    public async Task<TQueryDTO> FindAsync(int id, CancellationToken cancellationToken = default)
    {
      TEntity getEntity = await _repository.GetByIdAsync(id, cancellationToken);

      if (getEntity != null)
        return _mapper.Map<TQueryDTO>(getEntity);
      else
        throw new EntityNotFoundException(typeof(TEntity), id);
    }
    public async Task<IEnumerable<TQueryDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
      IEnumerable<TEntity> list = await _repository.AllAsync(cancellationToken);
      return _mapper.Map<IEnumerable<TQueryDTO>>(list);
    }
    public async Task<TQueryDTO> InsertAsync(TCommandDTO objDTO, CancellationToken cancellationToken = default)
    {
      TEntity addEntity = Mapper.Map<TEntity>(objDTO);
      await _repository.AddAsync(addEntity, cancellationToken);
      await _unitOfWork.CommitAsync(cancellationToken);
      return Mapper.Map<TQueryDTO>(addEntity);
    }
    public async Task<TQueryDTO> UpdateAsync(TCommandDTO objDTO, CancellationToken cancellationToken = default)
    {
      TEntity updatedEntity = await _repository.GetByIdAsync(Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id), cancellationToken);

      if (updatedEntity == null)
        throw new EntityNotFoundException(typeof(TEntity), Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id));

      Mapper.Map(objDTO, updatedEntity);
      _repository.Update(updatedEntity);
      await _unitOfWork.CommitAsync(cancellationToken);
      return Mapper.Map<TQueryDTO>(updatedEntity);
    }
    public async Task<IEnumerable<TQueryDTO>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
      IEnumerable<TEntity> list = await _repository.FilterAsync(predicate, cancellationToken);
      return _mapper.Map<IEnumerable<TQueryDTO>>(list);
    }
    public async Task<TQueryDTO> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
      TEntity getEntity = await _repository.FilterSingleAsync(predicate, cancellationToken);

      if (getEntity != null)
        return _mapper.Map<TQueryDTO>(getEntity);
      else
        throw new EntityNotFoundException(typeof(TEntity));
    }
    public async Task<IEnumerable<TQueryDTO>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
      IEnumerable<TEntity> list = await _repository.GetPagedAsync(pageNumber, pageSize, cancellationToken);
      return _mapper.Map<IEnumerable<TQueryDTO>>(list);
    }
    public async Task<IEnumerable<TQueryDTO>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
      IEnumerable<TEntity> list = await _repository.GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken);
      return _mapper.Map<IEnumerable<TQueryDTO>>(list);
    }
  }
}

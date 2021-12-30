using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;
using Ardalis.GuardClauses;

using Microsoft.EntityFrameworkCore;

using CA.Core.Exceptions;
using CA.Core.Interfaces.Base;
using CA.Core.Interfaces.Management;
using CA.Core.Interfaces.Services.Base;

namespace CA.Infrastructure.Persistence.Services.Base
{
  public abstract class CRUDService<TGetDto, TAddDto, TUpdDto, TDelDto, TKey, TEntity, TRepoAll, TContext> : ICRUDService<TGetDto, TAddDto, TUpdDto, TDelDto, TKey, TEntity, TRepoAll, TContext>
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
    
    public CRUDService(TRepoAll repository, IUnitOfWork<TContext> unitOfWork, IMapper mapper)
    {
      _repository = Guard.Against.Null(repository, nameof(repository));
      _mapper = Guard.Against.Null(mapper, nameof(mapper));
      _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
    }

    public async Task<TDelDto> DeleteAsync(TDelDto objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
    {
      TEntity deletedEntity = await _repository.GetByIdAsync(Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id), cancellationToken);

      if (deletedEntity == null)
        throw new EntityNotFoundException(typeof(TEntity), Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id));

      if (autoSave)
      {
        Mapper.Map(objDTO, deletedEntity); deletedEntity.IsDeleted = true; deletedEntity.DeleteDate = DateTime.UtcNow;
        _repository.Update(deletedEntity);
      }
      else
        _repository.Delete(deletedEntity);

      await _unitOfWork.CommitAsync(cancellationToken);
      return Mapper.Map<TDelDto>(deletedEntity);
    }

    public async Task<TGetDto> FindAsync(int id, CancellationToken cancellationToken = default)
    {
      TEntity getEntity = await _repository.GetByIdAsync(id, cancellationToken);

      if (!getEntity.IsDeleted)
        return _mapper.Map<TGetDto>(getEntity);
      else
        throw new EntityNotFoundException(typeof(TEntity), id);
    }

    public async Task<IEnumerable<TGetDto>> GetAll(CancellationToken cancellationToken = default)
    {
      IEnumerable<TEntity> list = await _repository.AllAsync(cancellationToken);
      return _mapper.Map<IEnumerable<TGetDto>>(list);
    }

    public async Task<TAddDto> InsertAsync(TAddDto objDTO, CancellationToken cancellationToken = default)
    {
      TEntity addEntity = Mapper.Map<TEntity>(objDTO);
      addEntity.CreationDate = DateTime.UtcNow;
      await _repository.AddAsync(addEntity, cancellationToken);
      await _unitOfWork.CommitAsync(cancellationToken);
      return Mapper.Map<TAddDto>(addEntity);
    }

    public async Task<TUpdDto> UpdateAsync(TUpdDto objDTO, CancellationToken cancellationToken = default)
    { 
      TEntity updatedEntity = await _repository.GetByIdAsync(Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id), cancellationToken);

      if (updatedEntity == null)
        throw new EntityNotFoundException(typeof(TEntity), Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id));

      Mapper.Map(objDTO, updatedEntity); updatedEntity.UpdateDate = DateTime.UtcNow;
      _repository.Update(updatedEntity);
      await _unitOfWork.CommitAsync(cancellationToken);
      return Mapper.Map<TUpdDto>(updatedEntity);
    }

    public async Task<IEnumerable<TGetDto>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
      IEnumerable<TEntity> list = await _repository.FilterAsync(predicate, cancellationToken);
      return _mapper.Map<IEnumerable<TGetDto>>(list);
    }
  }
}

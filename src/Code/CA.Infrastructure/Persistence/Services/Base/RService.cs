using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;
using Ardalis.GuardClauses;

using Microsoft.EntityFrameworkCore;

using CA.Core.Interfaces.Base;
using CA.Core.Interfaces.Management;
using CA.Core.Interfaces.Services.Base;

namespace CA.Infrastructure.Persistence.Services.Base
{
  public abstract class RService<TGetDto, TKey, TEntity, TRepoRead, TContext> : IRService<TGetDto, TKey, TEntity, TRepoRead, TContext>
    where TEntity : class, IEntityBase<TKey> 
    where TRepoRead : IReadRepository<TEntity, TContext> 
    where TContext : DbContext, new()
  {
    internal readonly IMapper _mapper;
    internal readonly TRepoRead _repository;
    internal readonly IUnitOfWork<TContext> _unitOfWork;

    protected IMapper Mapper => _mapper;
    protected TRepoRead Repository => _repository;
    protected IUnitOfWork<TContext> UnitOfWork => _unitOfWork;

    public RService(TRepoRead repository, IUnitOfWork<TContext> unitOfWork, IMapper mapper)
    {
      _unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
      _repository = Guard.Against.Null(repository, nameof(repository));
      _mapper = Guard.Against.Null(mapper, nameof(mapper));
    }

    public async Task<IEnumerable<TGetDto>> FilterAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
      IEnumerable<TEntity> list = await _repository.FilterAsync(predicate, cancellationToken);
      return _mapper.Map<IEnumerable<TGetDto>>(list);
    }

    public async Task<TGetDto> FindAsync(int id, CancellationToken cancellationToken = default)
    {
      TEntity user = await _repository.GetByIdAsync(id, cancellationToken);
      return _mapper.Map<TGetDto>(user);
    }

    public async Task<IEnumerable<TGetDto>> GetAll(CancellationToken cancellationToken = default)
    {
      IEnumerable<TEntity> list = await _repository.AllAsync(cancellationToken);
      return _mapper.Map<IEnumerable<TGetDto>>(list);
    }
  }
}

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.DTO.Base;
using CA.Domain.Entities;
using CA.Domain.Exceptions;
using CA.Domain.Entities.Base;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Services;
using CA.Domain.Interfaces.Management;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
    public class StoreService : CRUDService<CommandDTO, int,
                                            Store, IStoreRepository<PatosaDbContext>,
                                            PatosaDbContext>, IStoreService
    {
        private readonly IDataShapeHelper<StoreDTO> _dataShaperHelper;

        public StoreService(IMapper mapper,
                            IUnitOfWork<PatosaDbContext> unitOfWork,
                            IStoreRepository<PatosaDbContext> storeRepository,
                            IDataShapeHelper<StoreDTO> dataShapeHelper) : base(mapper, storeRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<Store> DeleteStoreAsync(DeleteStoreDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false, cancellationToken);

            if (ifExists == null)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return await DeleteAsync(objDTO, false, cancellationToken);
        }
        public async Task<Store> FindStoreAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetStoresAsync(Expression<Func<Store, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<StoreDTO>>(await GetAllAsync(predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedStoresAsync(int pageNumber, int pageSize, Expression<Func<Store, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) => (predicate == null) ?
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<StoreDTO>>(await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken)), fields) :
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<StoreDTO>>(await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<Store> InsertStoreAsync(CreateStoreDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Name == objDTO.Name && u.IsDeleted == false, cancellationToken);

            if (ifExists.Any())
                throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.Name);
            else
                return await InsertAsync(objDTO, cancellationToken);
        }
        public async Task<Store> UpdateStoreAsync(UpdateStoreDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false, cancellationToken);

            if (ifExists == null)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return await UpdateAsync(objDTO, cancellationToken);
        }
    }
}

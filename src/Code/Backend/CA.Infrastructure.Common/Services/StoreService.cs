using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;
using Microsoft.Extensions.Options;

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
    public class StoreService : CRUDService<StoreDTO, CommandDTO, int,
                                            Store, IStoreRepository<PatosaDbContext>,
                                            PatosaDbContext>, IStoreService
    {
        private readonly IDataShapeHelper<StoreDTO> _dataShaperHelper;

        public StoreService(IMapper mapper,
                            IUnitOfWork<PatosaDbContext> unitOfWork,
                            IStoreRepository<PatosaDbContext> storeRepository,
                            IDataShapeHelper<StoreDTO> dataShapeHelper) : base(mapper, storeRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<StoreDTO> FindStoreAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetStoresAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null) =>
            await _dataShaperHelper.ShapeDataAsync(await GetAllAsync(cancellationToken, fields, orderBy), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedStoresAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, Expression<Func<Store, bool>> predicate = null, string fields = null, string orderBy = null) =>
            (predicate == null) ? await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, cancellationToken, fields, orderBy), fields) :
                                    await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, fields, orderBy), fields);
        public async Task<CreateStoreDTO> InsertStoreAsync(CreateStoreDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Name == objDTO.Name && u.IsDeleted == false);

            if (ifExists.Count() > 0)
                throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.Name);
            else
                return Mapper.Map<CreateStoreDTO>(await InsertAsync(objDTO, cancellationToken));
        }
        public async Task<UpdateStoreDTO> UpdateStoreAsync(UpdateStoreDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

            if (ifExists == null)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return Mapper.Map<UpdateStoreDTO>(await UpdateAsync(objDTO, cancellationToken));
        }
        public async Task<DeleteStoreDTO> DeleteStoreAsync(DeleteStoreDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

            if (ifExists == null | ifExists.Count() == 0)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return Mapper.Map<DeleteStoreDTO>(await DeleteAsync(objDTO, autoSave, cancellationToken));
        }
    }
}

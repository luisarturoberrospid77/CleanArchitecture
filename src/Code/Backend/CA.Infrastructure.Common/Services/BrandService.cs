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
    public class BrandService : CRUDService<BrandDTO, CommandDTO, int,
                                            Brand, IBrandRepository<PatosaDbContext>,
                                            PatosaDbContext>, IBrandService
    {
        private readonly IDataShapeHelper<BrandDTO> _dataShaperHelper;

        public BrandService(IMapper mapper,
                            IUnitOfWork<PatosaDbContext> unitOfWork,
                            IBrandRepository<PatosaDbContext> brandRepository,
                            IDataShapeHelper<BrandDTO> dataShapeHelper) : base(mapper, brandRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<BrandDTO> FindBrandAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetBrandsAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null) =>
            await _dataShaperHelper.ShapeDataAsync(await GetAllAsync(cancellationToken, fields, orderBy), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedBrandsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, Expression<Func<Brand, bool>> predicate = null, string fields = null, string orderBy = null) =>
            (predicate == null) ? await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, cancellationToken, fields, orderBy), fields) :
                                    await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, fields, orderBy), fields);
        public async Task<CreateBrandDTO> InsertBrandAsync(CreateBrandDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Name == objDTO.Name && u.IsDeleted == false);

            if (ifExists.Count() > 0)
                throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.Name);
            else
                return Mapper.Map<CreateBrandDTO>(await InsertAsync(objDTO, cancellationToken));
        }
        public async Task<UpdateBrandDTO> UpdateBrandAsync(UpdateBrandDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

            if (ifExists == null)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return Mapper.Map<UpdateBrandDTO>(await UpdateAsync(objDTO, cancellationToken));
        }
        public async Task<DeleteBrandDTO> DeleteBrandAsync(DeleteBrandDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

            if (ifExists == null | ifExists.Count() == 0)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return Mapper.Map<DeleteBrandDTO>(await DeleteAsync(objDTO, autoSave, cancellationToken));
        }
    }
}

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
    public class BrandService : CRUDService<CommandDTO, int,
                                            Brand, IBrandRepository<PatosaDbContext>,
                                            PatosaDbContext>, IBrandService
    {
        private readonly IDataShapeHelper<BrandDTO> _dataShaperHelper;

        public BrandService(IMapper mapper,
                            IUnitOfWork<PatosaDbContext> unitOfWork,
                            IBrandRepository<PatosaDbContext> brandRepository,
                            IDataShapeHelper<BrandDTO> dataShapeHelper) : base(mapper, brandRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<Brand> DeleteBrandAsync(DeleteBrandDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false, cancellationToken);

            if (ifExists == null)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return await DeleteAsync(objDTO, false, cancellationToken);
        }
        public async Task<Brand> FindBrandAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetBrandsAsync(Expression<Func<Brand, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<BrandDTO>>(await GetAllAsync(predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedBrandsAsync(int pageNumber, int pageSize, Expression<Func<Brand, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default) => (predicate == null) ?
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<BrandDTO>>(await GetPagedAsync(pageNumber, pageSize, fields, orderBy, cancellationToken)), fields) :
                await _dataShaperHelper.ShapeDataAsync(Mapper.Map<IEnumerable<BrandDTO>>(await GetPagedAsync(pageNumber, pageSize, predicate, fields, orderBy, cancellationToken)), fields);
        public async Task<Brand> InsertBrandAsync(CreateBrandDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Name == objDTO.Name && u.IsDeleted == false, cancellationToken);

            if (ifExists.Any())
                throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.Name);
            else
                return await InsertAsync(objDTO, cancellationToken);
        }
        public async Task<Brand> UpdateBrandAsync(UpdateBrandDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false, cancellationToken);

            if (ifExists == null)
                throw new EntityNotFoundException(objDTO.Id.ToString());
            else
                return await UpdateAsync(objDTO, cancellationToken);
        }
    }
}

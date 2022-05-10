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
    public class CustomerService : CRUDService<CustomerDTO, CommandDTO, int,
                                               Customer, ICustomerRepository<PatosaDbContext>,
                                               PatosaDbContext>, ICustomerService
    {
        private readonly IDataShapeHelper<CustomerDTO> _dataShaperHelper;

        public CustomerService(IMapper mapper,
                               IUnitOfWork<PatosaDbContext> unitOfWork,
                               ICustomerRepository<PatosaDbContext> customerRepository,
                               IDataShapeHelper<CustomerDTO> dataShapeHelper) : base(mapper, customerRepository, unitOfWork)
        { _dataShaperHelper = dataShapeHelper; }
        public async Task<CustomerDTO> FindCustomerAsync(int id, CancellationToken cancellationToken = default) =>
            await FindAsync(id, cancellationToken);
        public async Task<IEnumerable<ShapedEntityDTO>> GetCustomersAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null) =>
            await _dataShaperHelper.ShapeDataAsync(await GetAllAsync(cancellationToken, fields, orderBy), fields);
        public async Task<IEnumerable<ShapedEntityDTO>> GetPagedCustomersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, Expression<Func<Customer, bool>> predicate = null, string fields = null, string orderBy = null) =>
            (predicate == null) ? await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, cancellationToken, fields, orderBy), fields) :
                                    await _dataShaperHelper.ShapeDataAsync(await GetPagedAsync(pageNumber, pageSize, predicate, cancellationToken, fields, orderBy), fields);
        public async Task<CreateCustomerDTO> InsertCustomerAsync(CreateCustomerDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.FirstName == objDTO.FirstName && u.LastName == objDTO.LastName && u.IsDeleted == false);

            if (ifExists.Count() > 0)
                throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.FirstName + " " + objDTO.LastName);
            else
                return Mapper.Map<CreateCustomerDTO>(await InsertAsync(objDTO, cancellationToken));
        }
        public async Task<UpdateCustomerDTO> UpdateCustomerAsync(UpdateCustomerDTO objDTO, CancellationToken cancellationToken = default)
        {
            var ifExists = await GetSingleAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

            if (ifExists == null)
                throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.Id.ToString());
            else
                return Mapper.Map<UpdateCustomerDTO>(await UpdateAsync(objDTO, cancellationToken));
        }
        public async Task<DeleteCustomerDTO> DeleteCustomerAsync(DeleteCustomerDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
        {
            var ifExists = await FilterAsync(u => u.Id == objDTO.Id & u.IsDeleted == false);

            if (ifExists.Count() == 0)
                throw new EntityAlreadyExistException(objDTO.GetType(), objDTO.Id.ToString());
            else
                return Mapper.Map<DeleteCustomerDTO>(await DeleteAsync(objDTO, autoSave, cancellationToken));
        }
    }
}

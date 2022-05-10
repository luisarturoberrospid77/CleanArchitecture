using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Entities.Base;

namespace CA.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        public int RowCount { get; }
        Task<CustomerDTO> FindCustomerAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetCustomersAsync(CancellationToken cancellationToken = default, string fields = null, string orderBy = null);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedCustomersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default, Expression<Func<Customer, bool>> predicate = null, string fields = null, string orderBy = null);
        Task<CreateCustomerDTO> InsertCustomerAsync(CreateCustomerDTO objDTO, CancellationToken cancellationToken = default);
        Task<UpdateCustomerDTO> UpdateCustomerAsync(UpdateCustomerDTO objDTO, CancellationToken cancellationToken = default);
        Task<DeleteCustomerDTO> DeleteCustomerAsync(DeleteCustomerDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

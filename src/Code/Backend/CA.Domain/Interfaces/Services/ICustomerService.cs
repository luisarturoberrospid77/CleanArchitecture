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
        Task<Customer> FindCustomerAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetCustomersAsync(Expression<Func<Customer, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShapedEntityDTO>> GetPagedCustomersAsync(int pageNumber, int pageSize, Expression<Func<Customer, bool>> predicate = null, string fields = null, string orderBy = null, CancellationToken cancellationToken = default);
        Task<Customer> InsertCustomerAsync(CreateCustomerDTO objDTO, CancellationToken cancellationToken = default);
        Task<Customer> UpdateCustomerAsync(UpdateCustomerDTO objDTO, CancellationToken cancellationToken = default);
        Task<Customer> DeleteCustomerAsync(DeleteCustomerDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
    }
}

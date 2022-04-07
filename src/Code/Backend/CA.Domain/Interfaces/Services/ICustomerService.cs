using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

using CA.Domain.DTO;

namespace CA.Domain.Interfaces.Services
{
  public interface ICustomerService
  {
    Task<CustomerDTO> FindCustomerAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CustomerDTO>> GetCustomersAsync(CancellationToken cancellationToken = default);
    Task<CreateCustomerDTO> InsertCustomerAsync(CreateCustomerDTO objDTO, CancellationToken cancellationToken = default);
    Task<UpdateCustomerDTO> UpdateCustomerAsync(UpdateCustomerDTO objDTO, CancellationToken cancellationToken = default);
    Task<DeleteCustomerDTO> DeleteCustomerAsync(DeleteCustomerDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default);
  }
}

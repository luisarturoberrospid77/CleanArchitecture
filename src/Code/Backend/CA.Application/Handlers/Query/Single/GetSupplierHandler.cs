using System.Threading;
using System.Threading.Tasks;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetSupplierHandler : IRequestHandler<GetSupplierQuery, SupplierDTO>
  {
    private readonly ISupplierService _supplierService;
    public GetSupplierHandler(ISupplierService supplierService) => _supplierService = supplierService;
    public async Task<SupplierDTO> Handle(GetSupplierQuery request, CancellationToken cancellationToken) =>
      await _supplierService.FindSupplierAsync(request.Id, cancellationToken);
  }
}

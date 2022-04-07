using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
  public class GetAllSupplierHandler : IRequestHandler<GetAllSupplierQuery, IEnumerable<SupplierDTO>>
  {
    private readonly ISupplierService _supplierService;
    public GetAllSupplierHandler(ISupplierService supplierService) => _supplierService = supplierService;
    public async Task<IEnumerable<SupplierDTO>> Handle(GetAllSupplierQuery request, CancellationToken cancellationToken) =>
      await _supplierService.GetSuppliersAsync(cancellationToken);
  }
}

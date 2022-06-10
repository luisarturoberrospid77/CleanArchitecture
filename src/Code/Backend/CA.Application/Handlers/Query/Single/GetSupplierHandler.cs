using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using CA.Domain.DTO;
using CA.Application.Queries;
using CA.Domain.Interfaces.Services;

namespace CA.Application.Handlers.Query
{
    public class GetSupplierHandler : IRequestHandler<GetSupplierQuery, SupplierDTO>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierService _supplierService;
        public GetSupplierHandler(ISupplierService supplierService, IMapper mapper) =>
            (_supplierService, _mapper) = (supplierService, mapper);
        public async Task<SupplierDTO> Handle(GetSupplierQuery request, CancellationToken cancellationToken) =>
            _mapper.Map<SupplierDTO>(await _supplierService.FindSupplierAsync(request.Id, cancellationToken));
    }
}

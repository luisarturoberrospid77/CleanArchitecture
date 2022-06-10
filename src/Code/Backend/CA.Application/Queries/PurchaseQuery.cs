using MediatR;

using CA.Domain.DTO;
using CA.Domain.Custom;
using CA.Domain.Wrappers;
using CA.Domain.Parameters;
using CA.Domain.Entities.Base;

namespace CA.Application.Queries
{
    public class GetAllPurchaseParameter : RequestParameter { }
    public class GetAllPurchaseQuery : IRequest<ApiResponse<MetaData<ShapedEntityDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Fields { get; set; }
        public string Search { get; set; }
        public string OrderBy { get; set; }
        public string Route { get; set; }
    }
    public class GetPurchaseQuery : IRequest<PurchaseDTO>
    {
        public int Id { get; }
        public GetPurchaseQuery(int id) => Id = id;
    }
}

using MediatR;

using CA.Domain.DTO;
using CA.Domain.Custom;
using CA.Domain.Wrappers;
using CA.Domain.Parameters;
using CA.Domain.Entities.Base;

namespace CA.Application.Queries
{
    public class GetAllStockArticleParameter : RequestParameter { }
    public class GetAllStockArticleQuery : IRequest<ApiResponse<MetaData<ShapedEntityDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Fields { get; set; }
        public string Search { get; set; }
        public string OrderBy { get; set; }
        public string Route { get; set; }
    }
    public class GetStockArticleQuery : IRequest<StockArticleDTO>
    {
        public int Id { get; }
        public GetStockArticleQuery(int id) => Id = id;
    }
}

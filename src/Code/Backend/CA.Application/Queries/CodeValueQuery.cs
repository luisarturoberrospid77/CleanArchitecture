using MediatR;

using CA.Domain.DTO;
using CA.Domain.Parameters;
using CA.Domain.Wrappers;
using CA.Domain.Custom;
using CA.Domain.Entities.Base;

namespace CA.Application.Queries
{
    public class GetAllCodeValueParameter : RequestParameter { }
    public class GetAllCodeValueQuery : IRequest<ApiResponse<MetaData<ShapedEntityDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Fields { get; set; }
        public string Search { get; set; }
        public string OrderBy { get; set; }
        public string Route { get; set; }
    }
    public class GetCodeValueQuery : IRequest<CodeValueDTO>
    {
        public int Id { get; }
        public GetCodeValueQuery(int id) => Id = id;
    }
}

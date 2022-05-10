using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
    public class UpdateCodeNameSpaceDTO : CommandDTO, IRequest<ApiResponse<UpdateCodeNameSpaceDTO>>
    {
        public int Id { get; set; }
        public string List { get; set; }
        public int? AccountIdUpdateDate { get; set; }
    }
}

using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
    public class CreateCodeNameSpaceDTO : CommandDTO, IRequest<ApiResponse<CreateCodeNameSpaceDTO>>
    {
        public string Name { get; set; }
        public string List { get; set; }
        public int AccountIdCreationDate { get; set; }
    }
}

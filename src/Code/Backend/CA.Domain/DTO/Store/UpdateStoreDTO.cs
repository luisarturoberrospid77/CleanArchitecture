using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
    public class UpdateStoreDTO : CommandDTO, IRequest<ApiResponse<UpdateStoreDTO>>
    {
        public int Id { get; set; }
        public string NumberPhone { get; set; }
        public int? AccountIdUpdateDate { get; set; }
    }
}

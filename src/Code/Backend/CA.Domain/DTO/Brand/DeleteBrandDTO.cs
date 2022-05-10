using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
    public class DeleteBrandDTO : CommandDTO, IRequest<ApiResponse<DeleteBrandDTO>>
    {
        public int Id { get; set; }
        public bool AutoSave { get; set; }
        public int? AccountIdDeleteDate { get; set; }
    }
}

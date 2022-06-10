using System.Collections.Generic;

using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
    public class CreateAssignmentDTO : CommandDTO, IRequest<ApiResponse<CreateAssignmentDTO>>
    {
        public int StoreId { get; set; }
        public string Comments { get; set; }
        public int AccountIdCreationDate { get; set; }
        public List<CreateAssignmentDetailDTO> Detail { get; set; }
    }
}

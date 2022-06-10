using System.Collections.Generic;

using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
    public class CreatePurchaseDTO : CommandDTO, IRequest<ApiResponse<CreatePurchaseDTO>>
    {
        public int SupplierId { get; set; }
        public string Comments { get; set; }
        public int AccountIdCreationDate { get; set; }
        public List<CreatePurchaseDetailDTO> Detail { get; set; }
    }
}

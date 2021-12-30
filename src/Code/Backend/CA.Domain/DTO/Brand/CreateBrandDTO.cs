using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
  public class CreateBrandDTO : CommandDTO, IRequest<ApiResponse<CreateBrandDTO>>
  {
    public string Name { get; set; }
    public int SupplierId { get; set; }
    public int AccountIdCreationDate { get; set; }
  }
}

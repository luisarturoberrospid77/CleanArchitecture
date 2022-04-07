using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
  public class UpdateBrandDTO : CommandDTO, IRequest<ApiResponse<UpdateBrandDTO>>
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int? AccountIdUpdateDate { get; set; }
  }
}

using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
  public class UpdateCodeValueDTO : CommandDTO, IRequest<ApiResponse<UpdateCodeValueDTO>>
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public int? AccountIdUpdateDate { get; set; }
  }
}

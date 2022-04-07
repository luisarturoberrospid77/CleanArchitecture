using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
  public class DeleteCustomerDTO : CommandDTO, IRequest<ApiResponse<DeleteCustomerDTO>>
  {
    public int Id { get; set; }
    public bool AutoSave { get; set; }
    public int? AccountIdDeleteDate { get; set; }
  }
}

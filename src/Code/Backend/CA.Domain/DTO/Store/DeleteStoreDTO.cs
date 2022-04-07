using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
  public class DeleteStoreDTO : CommandDTO, IRequest<ApiResponse<DeleteStoreDTO>>
  {
    public int Id { get; set; }
    public bool AutoSave { get; set; }
    public int? AccountIdDeleteDate { get; set; }
  }
}

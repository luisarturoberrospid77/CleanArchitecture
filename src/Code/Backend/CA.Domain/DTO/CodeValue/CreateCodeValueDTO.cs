using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
  public class CreateCodeValueDTO : CommandDTO, IRequest<ApiResponse<CreateCodeValueDTO>>
  {
    public int ValueId { get; set; }
    public int CodeNameSpaceId { get; set; }
    public string Description { get; set; }
    public bool IsRoot { get; set; }
    public int ParentId { get; set; }
    public int OrderBy { get; set; }
    public int AccountIdCreationDate { get; set; }
  }
}

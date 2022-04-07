using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
  public class CreateArticleDTO : CommandDTO, IRequest<ApiResponse<CreateArticleDTO>>
  {
    public string ShortName { get; set; }
    public string Description { get; set; }
    public int DepartamentId { get; set; }
    public int ProductTypeId { get; set; }
    public int SupplierId { get; set; }
    public int BrandId { get; set; }
    public string ImageArticle { get; set; }
    public int AccountIdCreationDate { get; set; }
  }
}

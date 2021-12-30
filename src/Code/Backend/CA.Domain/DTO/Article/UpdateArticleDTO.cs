using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
  public class UpdateArticleDTO : CommandDTO, IRequest<ApiResponse<UpdateArticleDTO>>
  {
    public int Id { get; set; }
    public string ImageArticle { get; set; }
    public int? AccountIdUpdateDate { get; set; }
  }
}

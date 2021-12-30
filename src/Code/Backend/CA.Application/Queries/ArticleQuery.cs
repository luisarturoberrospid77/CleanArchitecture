using System.Collections.Generic;

using MediatR;

using CA.Domain.DTO;

namespace CA.Application.Queries
{
  public class GetAllArticleQuery : IRequest<IEnumerable<ArticleDTO>> { }
  public class GetArticleQuery : IRequest<ArticleDTO>
  {
    public int Id { get; }
    public GetArticleQuery(int id) => Id = id;
  }
}

using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class UpdateArticleValidator : AbstractValidator<UpdateArticleDTO>
  {
    public UpdateArticleValidator()
    {
      Include(new UpdateIdArticle());
      Include(new UpdatePriceArticle());
      Include(new UpdateAccountIdArticle());
    }
  }
}

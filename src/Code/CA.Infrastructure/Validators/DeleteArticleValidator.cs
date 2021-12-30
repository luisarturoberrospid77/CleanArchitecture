using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class DeleteArticleValidator : AbstractValidator<DeleteArticleDTO>
  {
    public DeleteArticleValidator()
    {
      Include(new DeleteAccountIdArticle());
      Include(new DeleteAutoSaveArticle());
      Include(new DeleteIdArticle());
    }
  }
}

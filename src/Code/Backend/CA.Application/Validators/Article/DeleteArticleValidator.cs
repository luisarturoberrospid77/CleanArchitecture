using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class DeleteArticleValidator : AbstractValidator<DeleteArticleDTO>
    {
        public DeleteArticleValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            Include(new DeleteAccountIdArticle());
            Include(new DeleteAutoSaveArticle());
            Include(new DeleteIdArticle());
        }
    }
}

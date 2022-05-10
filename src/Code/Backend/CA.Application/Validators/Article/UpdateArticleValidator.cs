using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class UpdateArticleValidator : AbstractValidator<UpdateArticleDTO>
    {
        public UpdateArticleValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            Include(new UpdateIdArticle());
            Include(new UpdateImageArticle());
            Include(new UpdateAccountIdArticle());
        }
    }
}

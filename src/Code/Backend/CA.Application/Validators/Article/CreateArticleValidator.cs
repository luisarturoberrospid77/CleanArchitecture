using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreateArticleValidator : AbstractValidator<CreateArticleDTO>
    {
        public CreateArticleValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            Include(new AddNameArticle());
            Include(new AddDescriptionArticle());
            Include(new AddDepartamentIdArticle());
            Include(new AddProductTypeArticle());
            Include(new AddSupplierIdArticle());
            Include(new AddBrandIdArticle());
            Include(new AddImageArticle());
            Include(new AddAccountIdArticle());
        }
    }
}

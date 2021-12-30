using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class CreateArticleValidator : AbstractValidator<CreateArticleDTO>
  {
    public CreateArticleValidator()
    {
      Include(new AddNameArticle());
      Include(new AddDescriptionArticle());
      Include(new AddPriceArticle());
      Include(new AddTotalInVaultArticle());
      Include(new AddDepartamentIdArticle());
      Include(new AddProductTypeArticle());
      Include(new AddSupplierIdArticle());
      Include(new AddBrandIdArticle());
      Include(new AddImageArticle());
      Include(new AddAccountIdArticle());
    }
  }
}

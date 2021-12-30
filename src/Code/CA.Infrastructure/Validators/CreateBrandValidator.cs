using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class CreateBrandValidator : AbstractValidator<CreateBrandDTO>
  {
    public CreateBrandValidator()
    {
      Include(new AddNameBrand());
      Include(new AddSupplierIdBrand());
      Include(new AddAccountIdBrand());
    }
  }
}

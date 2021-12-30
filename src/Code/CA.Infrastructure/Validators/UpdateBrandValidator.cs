using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class UpdateBrandValidator : AbstractValidator<UpdateBrandDTO>
  {
    public UpdateBrandValidator()
    {
      Include(new UpdateIdBrand());
      Include(new UpdateNameBrand());
      Include(new UpdateAccountIdBrand());
    }
  }
}

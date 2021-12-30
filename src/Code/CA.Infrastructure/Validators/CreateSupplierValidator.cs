using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class CreateSupplierValidator : AbstractValidator<CreateSupplierDTO>
  {
    public CreateSupplierValidator()
    {
      Include(new AddNameSupplier());
      Include(new AddAdressSupplier());
      Include(new AddAccountIdSupplier());
    }
  }
}

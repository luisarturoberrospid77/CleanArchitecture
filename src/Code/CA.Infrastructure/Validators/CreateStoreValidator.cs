using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class CreateStoreValidator : AbstractValidator<CreateStoreDTO>
  {
    public CreateStoreValidator()
    {
      Include(new AddNameStore());
      Include(new AddAdressStore());
      Include(new AddAccountIdStore());
    }
  }
}

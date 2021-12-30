using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class UpdateStoreValidator : AbstractValidator<UpdateStoreDTO>
  {
    public UpdateStoreValidator()
    {
      Include(new UpdateAccountIdStore());
      Include(new UpdateIdStore());
      Include(new UpdateNameStore());
    }
  }
}

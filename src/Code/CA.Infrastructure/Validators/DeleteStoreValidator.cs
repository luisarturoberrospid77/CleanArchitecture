using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class DeleteStoreValidator : AbstractValidator<DeleteStoreDTO>
  {
    public DeleteStoreValidator()
    {
      Include(new DeleteIdStore());
      Include(new DeleteAutoSaveStore());
      Include(new DeleteAccountIdStore());
    }
  }
}

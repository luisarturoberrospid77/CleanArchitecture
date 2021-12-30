using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class DeleteSupplierValidator : AbstractValidator<DeleteSupplierDTO>
  {
    public DeleteSupplierValidator()
    {
      Include(new DeleteIdSupplier());
      Include(new DeleteAutoSaveSupplier());
      Include(new DeleteAccountIdSupplier());
    }
  }
}

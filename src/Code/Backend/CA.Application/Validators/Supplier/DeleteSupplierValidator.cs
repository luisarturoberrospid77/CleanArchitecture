using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
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

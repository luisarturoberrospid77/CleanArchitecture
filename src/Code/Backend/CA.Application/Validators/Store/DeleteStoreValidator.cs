using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
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

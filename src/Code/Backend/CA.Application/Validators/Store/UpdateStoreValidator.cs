using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class UpdateStoreValidator : AbstractValidator<UpdateStoreDTO>
    {
        public UpdateStoreValidator()
        {
            Include(new UpdateAccountIdStore());
            Include(new UpdateIdStore());
            Include(new UpdateNumberPhoneStore());
        }
    }
}

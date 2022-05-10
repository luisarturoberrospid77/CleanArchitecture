using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class DeleteBrandValidator : AbstractValidator<DeleteBrandDTO>
    {
        public DeleteBrandValidator()
        {
            Include(new DeleteAccountIdBrand());
            Include(new DeleteAutoSaveBrand());
            Include(new DeleteIdBrand());
        }
    }
}

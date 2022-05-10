using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
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

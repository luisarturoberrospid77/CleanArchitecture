using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreateBrandValidator : AbstractValidator<CreateBrandDTO>
    {
        public CreateBrandValidator()
        {
            Include(new AddNameBrand());
            Include(new AddSupplierIdBrand());
            Include(new AddAccountIdBrand());
        }
    }
}

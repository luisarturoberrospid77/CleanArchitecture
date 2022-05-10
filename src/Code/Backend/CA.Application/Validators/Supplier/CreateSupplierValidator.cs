using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierDTO>
    {
        public CreateSupplierValidator()
        {
            Include(new AddNameSupplier());
            Include(new AddAdressSupplier());
            Include(new AddPostalCodeSuplier());
            Include(new AddCountryCodeSupplier());
            Include(new AddEmailSupplier());
            Include(new AddNumberPhoneSupplier());
            Include(new AddFederalEntityCodeSupplier());
            Include(new AddMunicipalityCodeSupplier());
            Include(new AddNeighborhoodCodeSupplier());
            Include(new AddAccountIdSupplier());
        }
    }
}

using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierDTO>
    {
        public UpdateSupplierValidator()
        {
            Include(new UpdateIdSupplier());
            Include(new UpdateAddressSupplier());
            Include(new UpdateCountryCodeSupplier());
            Include(new UpdateFederalEntityCodeSupplier());
            Include(new UpdateMunicipalityCodeSupplier());
            Include(new UpdateNeighborhoodCodeSupplier());
            Include(new UpdateNumberPhoneSupplier());
            Include(new UpdateAccountIdSupplier());
        }
    }
}

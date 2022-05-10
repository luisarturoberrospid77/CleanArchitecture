using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreateStoreValidator : AbstractValidator<CreateStoreDTO>
    {
        public CreateStoreValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            Include(new AddNameStore());
            Include(new AddAdressStore());
            Include(new AddNumberPhoneStore());
            Include(new AddPostalCodeStore());
            Include(new AddCountryCodeStore());
            Include(new AddFederalEntityCodeStore());
            Include(new AddMunicipalityCodeStore());
            Include(new AddNeighborhoodCodeStore());
            Include(new AddAccountIdStore());
        }
    }
}

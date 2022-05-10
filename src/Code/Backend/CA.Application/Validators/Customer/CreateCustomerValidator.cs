using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerDTO>
    {
        public CreateCustomerValidator()
        {
            Include(new AddFirstNameCustomer());
            Include(new AddLastNameCustomer());
            Include(new AddAddressCustomer());
            Include(new AddEmailCustomer());
            Include(new AddCurpCodeCustomer());
            Include(new AddCountryCodeCustomer());
            Include(new AddFederalEntityCodeCustomer());
            Include(new AddMunicipalityCodeCustomer());
            Include(new AddNeighborhoodCodeCustomer());
            Include(new AddPostalCodeCustomer());
            Include(new AddNumberPhoneCustomer());
            Include(new AddRfcCodeCustomer());
            Include(new AddAccountIdCustomer());
        }
    }
}

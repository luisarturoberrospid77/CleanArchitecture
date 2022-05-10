using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerDTO>
    {
        public UpdateCustomerValidator()
        {
            Include(new UpdateIdCustomer());
            Include(new UpdateAddressCustomer());
            Include(new UpdateCountryCodeCustomer());
            Include(new UpdateCurpCodeCustomer());
            Include(new UpdateEmailCustomer());
            Include(new UpdateFederalEntityCodeCustomer());
            Include(new UpdateMunicipalityCodeCustomer());
            Include(new UpdateNeighborhoodCodeCustomer());
            Include(new UpdateNumberPhoneCustomer());
            Include(new UpdateRfcCodeCustomer());
            Include(new UpdateAccountIdCustomer());
        }
    }
}

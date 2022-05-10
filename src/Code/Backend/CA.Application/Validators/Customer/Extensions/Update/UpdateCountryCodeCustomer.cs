using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class UpdateCountryCodeCustomer : AbstractValidator<UpdateCustomerDTO>
    {
        public UpdateCountryCodeCustomer()
        {
            RuleFor(u => u.CountryCode).Cascade(CascadeMode.Stop)
                                       .Must(u => u >= 1).WithMessage("El identificador del código del cliente no puede ser negativo o cero.")
                                       .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,3}$")).WithMessage("Formato de código de país del cliente incorrecto.");
        }
    }
}

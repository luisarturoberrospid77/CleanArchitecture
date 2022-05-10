using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddPostalCodeCustomer : AbstractValidator<CreateCustomerDTO>
    {
        public AddPostalCodeCustomer()
        {
            RuleFor(u => u.PostalCode).Cascade(CascadeMode.Stop)
                                      .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El código postal del cliente no puede ser vacío o nulo.")
                                      .Must(u => RegexExtensions.VerifyValue(u, @"^\d{4,5}$")).WithMessage("Formato de código postal del cliente incorrecto.");
        }
    }
}

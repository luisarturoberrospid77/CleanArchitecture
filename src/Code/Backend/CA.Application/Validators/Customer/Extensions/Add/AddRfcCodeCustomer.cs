using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddRfcCodeCustomer : AbstractValidator<CreateCustomerDTO>
    {
        public AddRfcCodeCustomer()
        {
            RuleFor(u => u.RfcCode).Cascade(CascadeMode.Stop)
                                   .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El RFC del cliente no puede ser vacío o nulo.")
                                   .Must(u => RegexExtensions.VerifyValue(u, @"^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))((-)?([A-Z\d]{3}))?$")).WithMessage("Formato de RFC del cliente incorrecto.");
        }
    }
}

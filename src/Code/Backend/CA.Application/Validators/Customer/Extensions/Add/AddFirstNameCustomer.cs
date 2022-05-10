using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddFirstNameCustomer : AbstractValidator<CreateCustomerDTO>
    {
        public AddFirstNameCustomer()
        {
            RuleFor(u => u.FirstName).Cascade(CascadeMode.Stop)
                                     .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El nombre del cliente no puede ser vacío o nulo.")
                                     .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del nombre del cliente incorrecto.");
        }
    }
}

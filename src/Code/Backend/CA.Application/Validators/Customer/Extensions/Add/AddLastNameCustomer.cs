using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddLastNameCustomer : AbstractValidator<CreateCustomerDTO>
    {
        public AddLastNameCustomer()
        {
            RuleFor(u => u.LastName).Cascade(CascadeMode.Stop)
                                    .Must(u => !string.IsNullOrEmpty(u)).WithMessage("Los apellidos del cliente no puede ser vacío o nulo.")
                                    .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato de los apellidos del cliente incorrecto.");
        }
    }
}

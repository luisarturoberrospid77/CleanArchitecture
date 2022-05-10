using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddEmailCustomer : AbstractValidator<CreateCustomerDTO>
    {
        public AddEmailCustomer()
        {
            RuleFor(u => u.Email).Cascade(CascadeMode.Stop)
                                 .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El correo electrónico del cliente no puede ser vacío o nulo.")
                                 .Must(u => RegexExtensions.VerifyValue(u, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")).WithMessage("Formato del correo electrónico del cliente incorrecto.");
        }
    }
}

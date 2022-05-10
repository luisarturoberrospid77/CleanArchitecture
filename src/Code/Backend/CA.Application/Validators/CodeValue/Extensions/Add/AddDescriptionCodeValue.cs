using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddDescriptionCodeValue : AbstractValidator<CreateCodeValueDTO>
    {
        public AddDescriptionCodeValue()
        {
            RuleFor(u => u.Description).Cascade(CascadeMode.Stop)
                                       .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El nombre de la opción no puede ser vacío o nulo.")
                                       .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del nombre corto de la opción incorrecto.");
        }
    }
}

using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddValueIdCodeValue : AbstractValidator<CreateCodeValueDTO>
    {
        public AddValueIdCodeValue()
        {
            RuleFor(u => u.ValueId).Cascade(CascadeMode.Stop)
                                   .Must(u => u >= 1).WithMessage("El identificador de la opción no puede ser negativo o cero.")
                                   .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddCodeNameSpaceIdCodeValue : AbstractValidator<CreateCodeValueDTO>
    {
        public AddCodeNameSpaceIdCodeValue()
        {
            RuleFor(u => u.CodeNameSpaceId).Cascade(CascadeMode.Stop)
                                           .Must(u => u >= 1).WithMessage("El identificador del espacio de nombres no puede ser negativo o cero.")
                                           .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

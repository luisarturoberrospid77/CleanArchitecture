using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class DeleteIdCodeValue : AbstractValidator<DeleteCodeValueDTO>
    {
        public DeleteIdCodeValue()
        {
            RuleFor(u => u.Id).Cascade(CascadeMode.Stop)
                              .Must(u => u >= 0).WithMessage("El identificador del código de opción no puede ser negativo o cero.")
                              .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

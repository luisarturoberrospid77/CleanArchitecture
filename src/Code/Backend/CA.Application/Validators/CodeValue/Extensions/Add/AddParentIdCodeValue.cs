using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddParentIdCodeValue : AbstractValidator<CreateCodeValueDTO>
    {
        public AddParentIdCodeValue()
        {
            RuleFor(u => u.ParentId).Cascade(CascadeMode.Stop)
                                    .Must(u => u >= 1).WithMessage("El identificador del nodo raíz no puede ser negativo o cero.")
                                    .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

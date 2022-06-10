using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    class AddQuantityAssignmentDetail : AbstractValidator<CreateAssignmentDetailDTO>
    {
        public AddQuantityAssignmentDetail()
        {
            RuleFor(u => u.Quantity).Cascade(CascadeMode.Stop)
                                    .Must(u => u >= 1).WithMessage("La cantidad de artículos para incluir en la órden de asignación a sucursal no puede ser negativo o cero.")
                                    .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");

        }
    }
}

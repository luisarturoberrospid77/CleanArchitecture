using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    class AddQuantityOrderDetail : AbstractValidator<CreateSaleDetailDTO>
    {
        public AddQuantityOrderDetail()
        {
            RuleFor(u => u.Quantity).Cascade(CascadeMode.Stop)
                                    .Must(u => u >= 1).WithMessage("La cantidad de artículos para incluir en la órden de compra a proveedor no puede ser negativo o cero.")
                                    .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

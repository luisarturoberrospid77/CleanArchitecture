using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddFederalEntityCodeSupplier : AbstractValidator<CreateSupplierDTO>
    {
        public AddFederalEntityCodeSupplier()
        {
            RuleFor(u => u.FederalEntityCode).Cascade(CascadeMode.Stop)
                                             .Must(u => u >= 1).WithMessage("El identificador de la entidad federativa del proveedor no puede ser negativo o cero.")
                                             .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

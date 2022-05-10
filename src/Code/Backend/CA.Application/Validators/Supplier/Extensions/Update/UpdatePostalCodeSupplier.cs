using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class UpdatePostalCodeSupplier : AbstractValidator<UpdateSupplierDTO>
    {
        public UpdatePostalCodeSupplier()
        {
            RuleFor(u => u.PostalCode).Cascade(CascadeMode.Stop)
                                      .Must(u => u >= 1).WithMessage("El identificador del código postal del proveedor no puede ser negativo o cero.")
                                      .Must(u => RegexExtensions.VerifyValue(u, @"^\d{4,5}$")).WithMessage("Formato de código postal del proveedor incorrecto.");
        }
    }
}

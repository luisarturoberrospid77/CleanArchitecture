using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddPostalCodeSuplier : AbstractValidator<CreateSupplierDTO>
    {
        public AddPostalCodeSuplier()
        {
            RuleFor(u => u.PostalCode).Cascade(CascadeMode.Stop)
                                      .NotNull().WithMessage("El código postal del proveedor no puede ser nulo.")
                                      .NotEmpty().WithMessage("El código postal del proveedor no puede ser vacío.")
                                      .Must(u => RegexExtensions.VerifyValue(u, @"^\d{4,5}$")).WithMessage("Formato de código postal del cliente incorrecto.");
        }
    }
}

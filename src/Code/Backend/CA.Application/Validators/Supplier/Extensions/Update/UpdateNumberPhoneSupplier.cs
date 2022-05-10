using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class UpdateNumberPhoneSupplier : AbstractValidator<UpdateSupplierDTO>
    {
        public UpdateNumberPhoneSupplier()
        {
            RuleFor(u => u.NumberPhone).Cascade(CascadeMode.Stop)
                                       .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El número de teléfono del proveedor no puede ser vacío o nulo.")
                                       .Must(u => RegexExtensions.VerifyValue(u, @"(\(\d{2}\)[.-]?|\d{2}[.-]?)?\d{4}[.-]?\d{4}$")).WithMessage("Formato del número de teléfono del cliente incorrecto.");
        }
    }
}

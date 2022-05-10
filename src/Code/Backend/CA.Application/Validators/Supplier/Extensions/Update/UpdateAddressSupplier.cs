using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class UpdateAddressSupplier : AbstractValidator<UpdateSupplierDTO>
    {
        public UpdateAddressSupplier()
        {
            RuleFor(u => u.Address).Cascade(CascadeMode.Stop)
                                   .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El domicilio del proveedor no puede ser vacío o nulo.")
                                   .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del domicilio del proveedor incorrecto.");
        }
    }
}

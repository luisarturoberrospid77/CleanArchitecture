using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddNameSupplier : AbstractValidator<CreateSupplierDTO>
    {
        public AddNameSupplier()
        {
            RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                                .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El nombre del proveedor no puede ser vacío o nulo.")
                                .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del nombre del proveedor incorrecto.");
        }
    }
}

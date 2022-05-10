using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddSupplierIdBrand : AbstractValidator<CreateBrandDTO>
    {
        public AddSupplierIdBrand()
        {
            RuleFor(u => u.SupplierId).Cascade(CascadeMode.Stop)
                                      .Must(u => u >= 0).WithMessage("El identificador del proveedor no puede ser negativo.")
                                      .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

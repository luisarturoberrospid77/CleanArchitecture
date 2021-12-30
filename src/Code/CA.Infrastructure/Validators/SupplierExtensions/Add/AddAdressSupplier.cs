using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddAdressSupplier : AbstractValidator<CreateSupplierDTO>
  {
    public AddAdressSupplier()
    {
      RuleFor(u => u.Address).Cascade(CascadeMode.Stop)
                             .NotNull().WithMessage("El domicilio del proveedor no puede ser nulo.")
                             .NotEmpty().WithMessage("El domicilio del proveedor no puede ser vacío.")
                             .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del domicilio del proveedor incorrecto.");
    }
  }
}

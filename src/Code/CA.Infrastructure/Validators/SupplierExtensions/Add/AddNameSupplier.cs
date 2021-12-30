using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddNameSupplier : AbstractValidator<CreateSupplierDTO>
  {
    public AddNameSupplier()
    {
      RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                          .NotNull().WithMessage("El nombre del proveedor no puede ser nulo.")
                          .NotEmpty().WithMessage("El nombre del proveedor no puede ser vacío.")
                          .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del nombre del proveedor incorrecto.");
    }
  }
}

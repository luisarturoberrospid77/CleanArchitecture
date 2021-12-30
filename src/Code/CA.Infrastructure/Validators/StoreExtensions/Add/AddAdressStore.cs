using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddAdressStore : AbstractValidator<CreateStoreDTO>
  {
    public AddAdressStore()
    {
      RuleFor(u => u.Address).Cascade(CascadeMode.Stop)
                             .NotNull().WithMessage("El domicilio de la sucursal no puede ser nulo.")
                             .NotEmpty().WithMessage("El domicilio de la sucursal no puede ser vacío.")
                             .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato de la dirección de la sucursal incorrecto.");
    }
  }
}

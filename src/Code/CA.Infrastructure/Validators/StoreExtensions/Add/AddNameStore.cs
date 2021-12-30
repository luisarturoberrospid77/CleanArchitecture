using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddNameStore : AbstractValidator<CreateStoreDTO>
  {
    public AddNameStore()
    {
      RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                          .NotNull().WithMessage("El nombre de la sucursal no puede ser nulo.")
                          .NotEmpty().WithMessage("El nombre de la sucursal no puede ser vacío.")
                          .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del nombre de la sucursal incorrecto.");
    }
  }
}

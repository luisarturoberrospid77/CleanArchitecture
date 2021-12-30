using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class UpdateNameStore : AbstractValidator<UpdateStoreDTO>
  {
    public UpdateNameStore()
    {
      RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                          .NotNull().WithMessage("La descripción de la sucursal no puede ser nulo.")
                          .NotEmpty().WithMessage("La descripción de la sucursal no puede ser vacío.")
                          .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato de la descripción de la sucursal incorrecto.");
    }
  }
}

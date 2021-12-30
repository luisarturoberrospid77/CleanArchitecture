using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class UpdateNameBrand : AbstractValidator<UpdateBrandDTO>
  {
    public UpdateNameBrand()
    {
      RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                          .NotNull().WithMessage("La descripción de la marca del artículo no puede ser nulo.")
                          .NotEmpty().WithMessage("La descripción de la marca del artículo no puede ser vacío.")
                          .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato de la descripción de la marca del artículo incorrecto.");
    }
  }
}

using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddDescriptionArticle : AbstractValidator<CreateArticleDTO>
  {
    public AddDescriptionArticle()
    {
      RuleFor(u => u.Description).Cascade(CascadeMode.Stop)
                                 .NotNull().WithMessage("La descripcíón del artículo no puede ser nulo.")
                                 .NotEmpty().WithMessage("La descripcíón del artículo no puede ser vacío.")
                                 .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato de la descripción del artículo incorrecto.");
    }
  }
}

using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddNameArticle : AbstractValidator<CreateArticleDTO>
  {
    public AddNameArticle()
    {
      RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                          .NotNull().WithMessage("El nombre corto del artículo no puede ser nulo.")
                          .NotEmpty().WithMessage("El nombre corto del artículo no puede ser vacío.")
                          .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del nombre corto del artículo incorrecto.");
    }
  }
}

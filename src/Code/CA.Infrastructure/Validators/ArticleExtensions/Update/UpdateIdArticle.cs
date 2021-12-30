using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class UpdateIdArticle : AbstractValidator<UpdateArticleDTO>
  {
    public UpdateIdArticle()
    {
      RuleFor(u => u.Id).Cascade(CascadeMode.Stop)
                        .Must(u => u >= 1).WithMessage("El identificador del artículo no puede ser negativo o cero.")
                        .Must(u => RegexExtensions.VerifyValue(u, @"^[0-9]+\z")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
    }
  }
}

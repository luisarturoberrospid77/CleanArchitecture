using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddPriceArticle : AbstractValidator<CreateArticleDTO>
  {
    public AddPriceArticle()
    {
      RuleFor(u => u.Price).Cascade(CascadeMode.Stop)
                           .GreaterThan(0).WithMessage("El precio del artículo no puede ser negativo o cero.")
                           .Must(u => RegexExtensions.VerifyValue(u, @"^[0-9]{1,13}(\.[0-9]{0,2})?$")).WithMessage("Formato de número decimal incorrecto: 13 dígitos de mantisa y 2 posiciones decimales.");
    }
  }
}

using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddProductTypeArticle : AbstractValidator<CreateArticleDTO>
  {
    public AddProductTypeArticle()
    {
      RuleFor(u => u.ProducttypeId).Cascade(CascadeMode.Stop)
                                   .Must(u => u >= 1).WithMessage("El tipo de producto asociado al artículo no puede ser negativo o cero.")
                                   .Must(u => RegexExtensions.VerifyValue(u, @"^[0-9]+\z")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
    }
  }
}

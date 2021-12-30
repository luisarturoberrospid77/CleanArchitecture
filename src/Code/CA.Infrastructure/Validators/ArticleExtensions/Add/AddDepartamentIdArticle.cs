using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddDepartamentIdArticle : AbstractValidator<CreateArticleDTO>
  {
    public AddDepartamentIdArticle()
    {
      RuleFor(u => u.DepartamentId).Cascade(CascadeMode.Stop)
                                   .Must(u => u >= 1).WithMessage("El departamento asociado al artículo no puede ser negativo o cero.")
                                   .Must(u => RegexExtensions.VerifyValue(u, @"^[0-9]+\z")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
    }
  }
}

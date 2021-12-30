using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddTotalInVaultArticle : AbstractValidator<CreateArticleDTO>
  {
    public AddTotalInVaultArticle()
    {
      RuleFor(u => u.TotalInVault).Cascade(CascadeMode.Stop)
                                  .Must(u => u >= 1).WithMessage("El total de artículos en bodega no puede ser negativo o cero.")
                                  .Must(u => RegexExtensions.VerifyValue(u, @"^[0-9]+\z")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
    }
  }
}

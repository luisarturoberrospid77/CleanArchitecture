using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddSupplierIdArticle : AbstractValidator<CreateArticleDTO>
  {
    public AddSupplierIdArticle()
    {
      RuleFor(u => u.SupplierId).Cascade(CascadeMode.Stop)
                                .Must(u => u >= 0).WithMessage("El identificador del proveedor del artículo no puede ser negativo.")
                                .Must(u => RegexExtensions.VerifyValue(u, @"^[0-9]+\z")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
    }
  }
}

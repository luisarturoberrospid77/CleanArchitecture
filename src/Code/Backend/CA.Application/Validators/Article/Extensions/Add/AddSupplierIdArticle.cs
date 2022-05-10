using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddSupplierIdArticle : AbstractValidator<CreateArticleDTO>
    {
        public AddSupplierIdArticle()
        {
            RuleFor(u => u.SupplierId).Cascade(CascadeMode.Stop)
                                      .Must(u => u >= 0).WithMessage("El identificador del proveedor del artículo no puede ser negativo.")
                                      .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

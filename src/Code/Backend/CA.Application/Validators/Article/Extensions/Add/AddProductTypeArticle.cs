using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddProductTypeArticle : AbstractValidator<CreateArticleDTO>
    {
        public AddProductTypeArticle()
        {
            RuleFor(u => u.ProductTypeId).Cascade(CascadeMode.Stop)
                                         .Must(u => u >= 1).WithMessage("El tipo de producto asociado al artículo no puede ser negativo o cero.")
                                         .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

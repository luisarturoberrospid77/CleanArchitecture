using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddPriceArticleOrderDetail : AbstractValidator<CreateSaleDetailDTO>
    {
        public AddPriceArticleOrderDetail()
        {
            RuleFor(u => u.SalePrice).Cascade(CascadeMode.Stop)
                                     .Must(u => u >= 0).WithMessage("El precio del artículo no puede ser negativo o cero.")
                                     .Must(u => RegexExtensions.VerifyValue(u, @"^-?(([1-9]\d*)|0)([\.\,]0*[1-9](0*[1-9])*)?$")).WithMessage("Formato de número decimal o monetario incorrecto: solo dígitos y separador de decimal.");
        }
    }
}

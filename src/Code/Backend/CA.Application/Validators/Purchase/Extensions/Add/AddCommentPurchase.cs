using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddCommentPurchase : AbstractValidator<CreatePurchaseDTO>
    {
        public AddCommentPurchase()
        {
            RuleFor(u => u.Comments).Cascade(CascadeMode.Stop)
                                    .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El comentario de la órden de compra no puede ser vacío o nulo.")
                                    .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del comentario de la órden de compra incorrecto.");
        }
    }
}

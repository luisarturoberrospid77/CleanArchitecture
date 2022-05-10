using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddDescriptionArticle : AbstractValidator<CreateArticleDTO>
    {
        public AddDescriptionArticle()
        {
            RuleFor(u => u.Description).Cascade(CascadeMode.Stop)
                                       .Must(u => !string.IsNullOrEmpty(u)).WithMessage("La descripción del artículo no puede ser vacío o nulo.")
                                       .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato de la descripción del artículo incorrecto.");
        }
    }
}

using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddNameArticle : AbstractValidator<CreateArticleDTO>
    {
        public AddNameArticle()
        {
            RuleFor(u => u.ShortName).Cascade(CascadeMode.Stop)
                                     .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El nombre corto del artículo no puede ser vacío o nulo.")
                                     .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del nombre corto del artículo incorrecto.");
        }
    }
}

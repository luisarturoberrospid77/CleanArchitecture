using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddNameBrand : AbstractValidator<CreateBrandDTO>
    {
        public AddNameBrand()
        {
            RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                                .Must(u => !string.IsNullOrEmpty(u)).WithMessage("La descripción de la marca del artículo no puede ser vacío o nulo.")
                                .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato de la descripción de la marca del artículo incorrecto.");
        }
    }
}

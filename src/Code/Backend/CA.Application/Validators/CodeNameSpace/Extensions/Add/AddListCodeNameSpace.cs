using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddListCodeNameSpace : AbstractValidator<CreateCodeNameSpaceDTO>
    {
        public AddListCodeNameSpace()
        {
            RuleFor(u => u.List).Cascade(CascadeMode.Stop)
                                .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El nombre del catálogo no puede ser vacío o nulo.")
                                .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del nombre corto del catálogo incorrecto.");
        }
    }
}

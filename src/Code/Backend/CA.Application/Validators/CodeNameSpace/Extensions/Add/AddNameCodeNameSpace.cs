using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddNameCodeNameSpace : AbstractValidator<CreateCodeNameSpaceDTO>
    {
        public AddNameCodeNameSpace()
        {
            RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                                .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El nombre del campo no puede ser vacío o nulo.")
                                .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del nombre corto del campo incorrecto.");
        }
    }
}

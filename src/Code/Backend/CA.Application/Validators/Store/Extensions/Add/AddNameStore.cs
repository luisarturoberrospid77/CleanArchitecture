using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddNameStore : AbstractValidator<CreateStoreDTO>
    {
        public AddNameStore()
        {
            RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                                .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El nombre de la sucursal no puede ser nulo o vacío.")
                                .Must(u => RegexExtensions.VerifyValue(u, @"^[\w\s]{2,255}$")).WithMessage("Formato del nombre de la sucursal incorrecto.");
        }
    }
}

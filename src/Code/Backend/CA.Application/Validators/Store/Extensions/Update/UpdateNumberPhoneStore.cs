using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class UpdateNumberPhoneStore : AbstractValidator<UpdateStoreDTO>
    {
        public UpdateNumberPhoneStore()
        {
            RuleFor(u => u.NumberPhone).Cascade(CascadeMode.Stop)
                                       .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El número de teléfono de la sucursal no puede ser nulo o vacío.")
                                       .Must(u => RegexExtensions.VerifyValue(u, @"(\(\d{2}\)[.-]?|\d{2}[.-]?)?\d{4}[.-]?\d{4}$")).WithMessage("Formato del número de teléfono de la sucursal incorrecto.");
        }
    }
}

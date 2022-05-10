using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddPostalCodeStore : AbstractValidator<CreateStoreDTO>
    {
        public AddPostalCodeStore()
        {
            RuleFor(u => u.PostalCode).Cascade(CascadeMode.Stop)
                                      .Must(u => u >= 1).WithMessage("El identificador del código postal de la sucursal no puede ser negativo o cero.")
                                      .Must(u => RegexExtensions.VerifyValue(u, @"^\d{4,5}$")).WithMessage("Formato de código postal de la sucursal incorrecto.");
        }
    }
}

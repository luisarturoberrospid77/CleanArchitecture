using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddAdressStore : AbstractValidator<CreateStoreDTO>
    {
        public AddAdressStore()
        {
            RuleFor(u => u.Address).Cascade(CascadeMode.Stop)
                                   .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El domicilio de la sucursal no puede ser nulo o vacío.")
                                   .Must(u => RegexExtensions.VerifyValue(u, @"[#$%&\-_(),':.,[\]\w\s\\/]{2,255}$")).WithMessage("Formato de la dirección de la sucursal incorrecto.");
        }
    }
}

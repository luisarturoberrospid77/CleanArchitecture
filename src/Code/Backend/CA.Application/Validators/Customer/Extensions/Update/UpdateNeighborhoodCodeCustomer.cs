using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class UpdateNeighborhoodCodeCustomer : AbstractValidator<UpdateCustomerDTO>
    {
        public UpdateNeighborhoodCodeCustomer()
        {
            RuleFor(u => u.NeighborhoodCode).Cascade(CascadeMode.Stop)
                                            .Must(u => u >= 1).WithMessage("El identificador de la colonia o comunidad del cliente no puede ser negativo o cero.")
                                            .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

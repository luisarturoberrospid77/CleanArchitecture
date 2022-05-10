using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class UpdateMunicipalityCodeCustomer : AbstractValidator<UpdateCustomerDTO>
    {
        public UpdateMunicipalityCodeCustomer()
        {
            RuleFor(u => u.MunicipalityCode).Cascade(CascadeMode.Stop)
                                            .Must(u => u >= 1).WithMessage("El identificador del municipio del cliente no puede ser negativo o cero.")
                                            .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

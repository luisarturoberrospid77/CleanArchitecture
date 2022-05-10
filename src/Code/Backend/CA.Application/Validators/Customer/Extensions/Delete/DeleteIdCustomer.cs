using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class DeleteIdCustomer : AbstractValidator<DeleteCustomerDTO>
    {
        public DeleteIdCustomer()
        {
            RuleFor(u => u.Id).Cascade(CascadeMode.Stop)
                              .Must(u => u >= 0).WithMessage("El identificador del cliente no puede ser negativo.")
                              .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

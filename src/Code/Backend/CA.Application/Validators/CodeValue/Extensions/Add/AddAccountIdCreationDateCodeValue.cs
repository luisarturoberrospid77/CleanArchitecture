using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddAccountIdCreationDateCodeValue : AbstractValidator<CreateCodeValueDTO>
    {
        public AddAccountIdCreationDateCodeValue()
        {
            RuleFor(u => u.AccountIdCreationDate).Cascade(CascadeMode.Stop)
                                           .Must(u => u >= 1).WithMessage("El identificador de la cuenta de usuario no puede ser negativo o cero.")
                                           .Must(u => RegexExtensions.VerifyValue(u, @"^\d{1,6}$")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
        }
    }
}

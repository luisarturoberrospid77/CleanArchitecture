using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddAccountIdSupplier : AbstractValidator<CreateSupplierDTO>
  {
    public AddAccountIdSupplier()
    {
      RuleFor(u => u.AccountIdCreationDate).Cascade(CascadeMode.Stop)
                                           .Must(u => u >= 1).WithMessage("El identificador de la cuenta de usuario no puede ser negativo o cero.")
                                           .Must(u => RegexExtensions.VerifyValue(u, @"^[0-9]+\z")).WithMessage("Formato de número entero incorrecto: solo dígitos.");
    }
  }
}

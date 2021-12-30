using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class DeleteAutoSaveSupplier : AbstractValidator<DeleteSupplierDTO>
  {
    public DeleteAutoSaveSupplier()
    {
      RuleFor(u => u.AutoSave).Cascade(CascadeMode.Stop)
                              .Must(u => RegexExtensions.VerifyValue(u, @"^(?i)(true|false)$")).WithMessage("Formato de valor booleano incorrecto: solo 'true' o 'false'.");
    }
  }
}

using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class DeleteAutoSaveStore : AbstractValidator<DeleteStoreDTO>
    {
        public DeleteAutoSaveStore()
        {
            RuleFor(u => u.AutoSave).Cascade(CascadeMode.Stop)
                                    .Must(u => RegexExtensions.VerifyValue(u, @"^(?i)(true|false)$")).WithMessage("Formato de valor booleano incorrecto: solo 'true' o 'false'.");
        }
    }
}

using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class DeleteCodeValueValidator : AbstractValidator<DeleteCodeValueDTO>
    {
        public DeleteCodeValueValidator()
        {
            Include(new DeleteIdCodeValue());
            Include(new DeleteAutoSaveCodeValue());
            Include(new DeleteAccountIdCodeValue());
        }
    }
}

using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class UpdateCodeValueValidator : AbstractValidator<UpdateCodeValueDTO>
    {
        public UpdateCodeValueValidator()
        {
            Include(new UpdateIdCodeValue());
            Include(new UpdateDescriptionCodeValue());
            Include(new UpdateAccountIdCodeValue());
        }
    }
}

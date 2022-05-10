using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreateCodeNameSpaceValidator : AbstractValidator<CreateCodeNameSpaceDTO>
    {
        public CreateCodeNameSpaceValidator()
        {
            Include(new AddNameCodeNameSpace());
            Include(new AddListCodeNameSpace());
            Include(new AddAccountIdCodeNameSpace());
        }
    }
}

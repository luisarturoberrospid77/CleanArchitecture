using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class UpdateCodeNameSpaceValidator : AbstractValidator<UpdateCodeNameSpaceDTO>
    {
        public UpdateCodeNameSpaceValidator()
        {
            Include(new UpdateIdCodeNameSpace());
            Include(new UpdateListCodeNameSpace());
            Include(new UpdateAccountIdCodeNameSpace());
        }
    }
}

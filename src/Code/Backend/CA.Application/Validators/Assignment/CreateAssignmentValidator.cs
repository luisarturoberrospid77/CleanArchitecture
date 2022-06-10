using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreateAssignmentValidator : AbstractValidator<CreateAssignmentDTO>
    {
        public CreateAssignmentValidator()
        {
            Include(new AddAccountIdAssignment());
            Include(new AddCommentAssignment());
            Include(new AddStoreIdAssignment());
        }
    }
}

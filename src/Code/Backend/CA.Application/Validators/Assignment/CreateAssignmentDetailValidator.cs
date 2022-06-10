using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreateAssignmentDetailValidator : AbstractValidator<CreateAssignmentDetailDTO>
    {
        public CreateAssignmentDetailValidator()
        {
            Include(new AddAccountIdAssignmentDetail());
            Include(new AddPurchasePriceAssignmentDetail());
            Include(new AddQuantityAssignmentDetail());
        }
    }
}

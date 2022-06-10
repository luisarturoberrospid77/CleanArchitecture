using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreatePurchaseValidator : AbstractValidator<CreatePurchaseDTO>
    {
        public CreatePurchaseValidator()
        {
            Include(new AddSupplierIdPurchase());
            Include(new AddCommentPurchase());
            Include(new AddDetailPurchase());
            Include(new AddAccountIdPurchase());
        }
    }
}

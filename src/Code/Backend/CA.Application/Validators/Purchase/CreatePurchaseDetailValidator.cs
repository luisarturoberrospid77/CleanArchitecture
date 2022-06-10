using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreatePurchaseDetailValidator : AbstractValidator<CreatePurchaseDetailDTO>
    {
        public CreatePurchaseDetailValidator()
        {
            Include(new AddSkuIdPurchaseDetail());
            Include(new AddPurchasePricePurchaseDetail());
            Include(new AddQuantityPurchaseDetail());
            Include(new AddAccountIdPurchaseDetail());
        }
    }
}

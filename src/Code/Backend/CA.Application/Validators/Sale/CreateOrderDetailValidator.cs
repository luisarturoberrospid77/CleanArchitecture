using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreateOrderDetailValidator : AbstractValidator<CreateSaleDetailDTO>
    {
        public CreateOrderDetailValidator()
        {
            Include(new AddAccountIdOrderDetail());
            Include(new AddQuantityOrderDetail());
            Include(new AddPriceArticleOrderDetail());
            Include(new AddSkuIdOrderDetail());
        }
    }
}

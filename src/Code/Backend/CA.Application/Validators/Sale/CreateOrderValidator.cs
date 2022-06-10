using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateSaleDTO>
    {
        public CreateOrderValidator()
        {
            Include(new AddAccountIdOrder());
            Include(new AddCommentOrder());
            Include(new AddDetailOrder());
            Include(new AddStoreIdOrder());
        }
    }
}

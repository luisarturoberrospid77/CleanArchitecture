using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerDTO>
    {
        public DeleteCustomerValidator()
        {
            Include(new DeleteIdCustomer());
            Include(new DeleteAutoSaveCustomer());
            Include(new DeleteAccountIdCustomer());
        }
    }
}

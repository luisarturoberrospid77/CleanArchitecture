using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class DeleteBrandValidator : AbstractValidator<DeleteBrandDTO>
  {
    public DeleteBrandValidator()
    {
      Include(new DeleteAccountIdBrand());
      Include(new DeleteAutoSaveBrand());
      Include(new DeleteIdBrand());
    }
  }
}

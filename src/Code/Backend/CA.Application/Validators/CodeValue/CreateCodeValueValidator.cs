using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class CreateCodeValueValidator : AbstractValidator<CreateCodeValueDTO>
    {
        public CreateCodeValueValidator()
        {
            Include(new AddValueIdCodeValue());
            Include(new AddCodeNameSpaceIdCodeValue());
            Include(new AddDescriptionCodeValue());
            Include(new AddIsRootCodeValue());
            Include(new AddParentIdCodeValue());
            Include(new AddOrderByCodeValue());
            Include(new AddAccountIdCreationDateCodeValue());
        }
    }
}

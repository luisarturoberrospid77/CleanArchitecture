using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class DeleteCodeNameSpace : AbstractValidator<DeleteCodeNameSpaceDTO>
    {
        public DeleteCodeNameSpace()
        {
            Include(new DeleteIdCodeNameSpace());
            Include(new DeleteAutoSaveCodeNameSpace());
            Include(new DeleteAccountIdCodeNameSpace());
        }
    }
}

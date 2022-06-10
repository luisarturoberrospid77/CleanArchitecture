using System.Linq;

using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class AddDetailAssignment : AbstractValidator<CreateAssignmentDTO>
    {
        public AddDetailAssignment()
        {
            RuleFor(u => u.Detail).Cascade(CascadeMode.Stop)
                                  .NotNull().WithMessage("El detalle de los artículos no puede ser nulo.")
                                  .NotEmpty().WithMessage("El detalle de los artículos no puede ser vacío.")
                                  .Must(u => u.Distinct().Count() == u.Count()).WithMessage("El detalle de los artículos no puede tener artículos duplicados.");
            RuleForEach(u => u.Detail).SetValidator(new CreateAssignmentDetailValidator());
        }
    }
}

using System.Linq;

using FluentValidation;

using CA.Domain.DTO;

namespace CA.Application.Validators
{
    public class AddDetailOrder : AbstractValidator<CreateSaleDTO>
    {
        public AddDetailOrder()
        {
            RuleFor(u => u.SaleDetail).Cascade(CascadeMode.Stop)
                                      .NotNull().WithMessage("El detalle de los artículos no puede ser nulo.")
                                      .NotEmpty().WithMessage("El detalle de los artículos no puede ser vacío.")
                                      .Must(u => u.Distinct().Count() == u.Count()).WithMessage("El detalle de los artículos no puede tener artículos duplicados.");
            RuleForEach(u => u.SaleDetail).SetValidator(new CreateOrderDetailValidator());
        }
    }
}

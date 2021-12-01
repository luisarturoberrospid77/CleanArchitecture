using System;

using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class StoreValidator : AbstractValidator<StoreDTO>
  {
    public StoreValidator()
    {
      RuleFor(u => u.StoreId).Cascade(CascadeMode.Stop)
                             .NotNull().When(u => u.UpdateDate != null).WithMessage("El identificador de la sucursal no puede ser nulo.")
                             .GreaterThan(0).When(u => u.UpdateDate != null).WithMessage("El identificador de la sucursal no puede ser cero o negativo.");
      RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                          .NotNull().WithMessage("El nombre de la sucursal no puede ser nulo.")
                          .NotEmpty().WithMessage("El nombre de la sucursal no puede ser vacío.")
                          .Length(2, 255).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.")
                          .Matches(@"^[\w\s]+$").WithMessage("Formato del nombre de la sucursal incorrecto.");
      RuleFor(u => u.Address).Cascade(CascadeMode.Stop)
                             .NotNull().WithMessage("El domicilio de la sucursal no puede ser nulo.")
                             .NotEmpty().WithMessage("El domicilio de la sucursal no puede ser vacío.")
                             .Length(2, 255).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.")
                             .Matches(@"^[\w\s]+$").WithMessage("Formato de la dirección de la sucursal incorrecto.");
      RuleFor(u => u.AccountId).Cascade(CascadeMode.Stop)
                               .NotEmpty().WithMessage("El identificador de la cuenta de usuario no puede ser vacío.")
                               .GreaterThan(0).WithMessage("El identificador de la cuenta de usuario no puede ser negativo o cero.");
      RuleFor(u => u.CreationDate).Cascade(CascadeMode.Stop)
                                  .NotNull().WithMessage("La fecha de creación del registro no puede ser vacío.")
                                  .LessThan(DateTime.Now).WithMessage("La fecha de creación del registro no puede anterior a la fecha actual.");
    }
  }
}

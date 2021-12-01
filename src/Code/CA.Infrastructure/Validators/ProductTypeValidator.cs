using System;

using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class ProductTypeValidator : AbstractValidator<ProductTypeDTO>
  {
    public ProductTypeValidator()
    {
      RuleFor(u => u.ProducttypeId).Cascade(CascadeMode.Stop)
                                   .NotNull().When(u => u.UpdateDate != null).WithMessage("El identificador del tipo de artículo no puede ser nulo.")
                                   .GreaterThan(0).When(u => u.UpdateDate != null).WithMessage("El identificador del tipo de artículo no puede ser cero o negativo.");
      RuleFor(u => u.Description).Cascade(CascadeMode.Stop)
                                 .NotNull().WithMessage("El nombre del tipo de artículo no puede ser nulo.")
                                 .NotEmpty().WithMessage("El nombre del tipo de artículo no puede ser vacío.")
                                 .Length(2, 255).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.")
                                 .Matches(@"^[\w\s]+$").WithMessage("Formato de descripción del tipo de artículo incorrecto.");
      RuleFor(u => u.AccountId).Cascade(CascadeMode.Stop)
                               .NotEmpty().WithMessage("El identificador de la cuenta de usuario no puede ser vacío.")
                               .GreaterThan(0).WithMessage("El identificador de la cuenta de usuario no puede ser negativo o cero.");
      RuleFor(u => u.CreationDate).Cascade(CascadeMode.Stop)
                                  .NotNull().WithMessage("La fecha de creación del registro no puede ser vacío.")
                                  .LessThan(DateTime.Now).WithMessage("La fecha de creación del registro no puede anterior a la fecha actual.");
    }
  }
}

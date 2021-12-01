using System;

using FluentValidation;

using CA.Core.DTO;

namespace CA.Infrastructure.Validators
{
  public class ArticleValidator : AbstractValidator<ArticleDTO>
  {
    public ArticleValidator()
    {
      RuleFor(u => u.SkuId).Cascade(CascadeMode.Stop)
                           .NotNull().When(u => u.UpdateDate != null).WithMessage("El identificador del artículo no puede ser nulo.")
                           .GreaterThan(0).When(u => u.UpdateDate != null).WithMessage("El identificador del artículo no puede ser cero o negativo.");
      RuleFor(u => u.Name).Cascade(CascadeMode.Stop)
                          .NotNull().WithMessage("El nombre corto del artículo no puede ser nulo.")
                          .NotEmpty().WithMessage("El nombre corto del artículo no puede ser vacío.")
                          .Length(2, 255).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.")
                          .Matches(@"^[\w\s]+$").WithMessage("Formato del nombre corto del artículo incorrecto.");
      RuleFor(u => u.Description).Cascade(CascadeMode.Stop)
                                 .NotNull().WithMessage("La descripción del artículo no puede ser nulo.")
                                 .NotEmpty().WithMessage("La descripcíón del artículo no puede ser vacío.")
                                 .Length(2, 255).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.")
                                 .Matches(@"^[\w\s]+$").WithMessage("Formato de descripción de artículo incorrecto.");
      RuleFor(u => u.Price).Cascade(CascadeMode.Stop)
                           .NotEmpty().WithMessage("El precio del artículo no puede ser vacío.")
                           .GreaterThan(0).WithMessage("El precio del artículo no puede ser negativo o cero.");
      RuleFor(u => u.TotalInVault).Cascade(CascadeMode.Stop)
                                  .NotEmpty().WithMessage("El total de artículos en la bodega no puede ser vacío.")
                                  .GreaterThan(0).WithMessage("El total de artículos en la bodega no puede ser negativo o cero.");
      RuleFor(u => u.TotalInShelf).Cascade(CascadeMode.Stop)
                                  .NotEmpty().WithMessage("El total de artículos en el anaquel no puede ser vacío.")
                                  .GreaterThan(0).WithMessage("El total de artículos en el anaquel no puede ser negativo o cero.");
      RuleFor(u => u.ProducttypeId).Cascade(CascadeMode.Stop)
                                   .NotEmpty().WithMessage("El tipo de artículo no puede ser vacío.")
                                   .GreaterThan(0).WithMessage("El tipo de artículo no puede ser negativo o cero.");
      RuleFor(u => u.StoreId).Cascade(CascadeMode.Stop)
                             .NotEmpty().WithMessage("El identificador de la sucursal no puede ser vacío.")
                             .GreaterThan(0).WithMessage("El identificador de la sucursal no puede ser negativo o cero.");
      RuleFor(u => u.AccountId).Cascade(CascadeMode.Stop)
                               .NotEmpty().WithMessage("El identificador de la cuenta de usuario no puede ser vacío.")
                               .GreaterThan(0).WithMessage("El identificador de la cuenta de usuario no puede ser negativo o cero.");
      RuleFor(u => u.CreationDate).Cascade(CascadeMode.Stop)
                                  .NotNull().WithMessage("La fecha de creación del registro no puede ser vacío.")
                                  .LessThan(DateTime.Now).WithMessage("La fecha de creación del registro no puede anterior a la fecha actual.");

    }
  }
}

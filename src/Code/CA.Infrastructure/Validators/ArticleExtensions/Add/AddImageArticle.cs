using FluentValidation;

using CA.Core.DTO;
using CA.Infrastructure.Extensions.Base;

namespace CA.Infrastructure.Validators
{
  public class AddImageArticle : AbstractValidator<CreateArticleDTO>
  {
    public AddImageArticle()
    {
      RuleFor(u => u.ImageArticle).Cascade(CascadeMode.Stop)
                                  .NotNull().WithMessage("La cadena en Base 64 de la imagen del artículo no puede ser nulo.")
                                  .NotEmpty().WithMessage("La cadena en Base 64 de la imagen del artículo no puede ser vacío.")
                                  .Must(u => RegexExtensions.VerifyValue(u, @"^data:image\/(?:gif|png|jpeg|jpg|bmp|webp|svg\+xml)(?:;charset=utf-8)?;base64,(?:[A-Za-z0-9]|[+/])+={0,2}$"))
                                  .WithMessage("Formato de archivo o imagen descriptiva del artículo incorrecto.");
    }
  }
}

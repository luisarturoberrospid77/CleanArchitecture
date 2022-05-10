using FluentValidation;

using CA.Domain.DTO;
using CA.Domain.Features;

namespace CA.Application.Validators
{
    public class AddCurpCodeCustomer : AbstractValidator<CreateCustomerDTO>
    {
        public AddCurpCodeCustomer()
        {
            RuleFor(u => u.CurpCode).Cascade(CascadeMode.Stop)
                                    .Must(u => !string.IsNullOrEmpty(u)).WithMessage("El CURP del cliente no puede ser vacío o nulo.")
                                    .Must(u => RegexExtensions.VerifyValue(u, @"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$")).WithMessage("Formato del CURP del cliente incorrecto.");
        }
    }
}

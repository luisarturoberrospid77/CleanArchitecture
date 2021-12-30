using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
  public class UpdateSupplierDTO : CommandDTO, IRequest<ApiResponse<UpdateSupplierDTO>>
  {
    public int Id { get; set; }
    public string Address { get; set; }
    public string NumberPhone { get; set; }
    public int PostalCode { get; set; }
    public int CountryCode { get; set; }
    public int FederalEntityCode { get; set; }
    public int MunicipalityCode { get; set; }
    public int NeighborhoodCode { get; set; }
    public int? AccountIdUpdateDate { get; set; }
  }
}

using MediatR;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;

namespace CA.Domain.DTO
{
  public class CreateSupplierDTO : CommandDTO, IRequest<ApiResponse<CreateSupplierDTO>>
  {
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string NumberPhone { get; set; }
    public int CountryCode { get; set; }
    public string PostalCode { get; set; }
    public int FederalEntityCode { get; set; }
    public int MunicipalityCode { get; set; }
    public int NeighborhoodCode { get; set; }
    public int AccountIdCreationDate { get; set; }
  }
}

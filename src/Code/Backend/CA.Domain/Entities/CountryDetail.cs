using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class CountryDetail : EntityBase<int>
  {
    public int CountryCode { get; set; }
    public int FederalEntityCode { get; set; }
    public string FederalEntityName { get; set; }
    public int MunicipalityCode { get; set; }
    public string MunicipalityName { get; set; }
    public string CityName { get; set; }
    public string ZoneName { get; set; }
    public int PostalCode { get; set; }
    public int TownshipId { get; set; }
    public string TownshipName { get; set; }
    public int TownshipTypeId { get; set; }
    public string TownshipTypeName { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual Country CountryCodeNavigation { get; set; }
  }
}

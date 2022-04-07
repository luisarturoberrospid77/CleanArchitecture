using System.Collections.Generic;

using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class Customer : EntityBase<int>
  {
    public Customer()
    {
      Orders = new HashSet<Order>();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string CurpCode { get; set; }
    public string RfcCode { get; set; }
    public string NumberPhone { get; set; }
    public int PostalCode { get; set; }
    public int CountryCode { get; set; }
    public int FederalEntityCode { get; set; }
    public int MunicipalityCode { get; set; }
    public int NeighborhoodCode { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual Country CountryCodeNavigation { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
  }
}

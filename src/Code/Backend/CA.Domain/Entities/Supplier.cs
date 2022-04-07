using System.Collections.Generic;

using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class Supplier : EntityBase<int>
  {
    public Supplier()
    {
      Articles = new HashSet<Article>();
      Brands = new HashSet<Brand>();
      ItemMovements = new HashSet<ItemMovement>();
      Purchases = new HashSet<Purchase>();
    }

    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string NumberPhone { get; set; }
    public int PostalCode { get; set; }
    public int CountryCode { get; set; }
    public int FederalEntityCode { get; set; }
    public int MunicipalityCode { get; set; }
    public int NeighborhoodCode { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual Country CountryCodeNavigation { get; set; }
    public virtual ICollection<Article> Articles { get; set; }
    public virtual ICollection<Brand> Brands { get; set; }
    public virtual ICollection<ItemMovement> ItemMovements { get; set; }
    public virtual ICollection<Purchase> Purchases { get; set; }
  }
}

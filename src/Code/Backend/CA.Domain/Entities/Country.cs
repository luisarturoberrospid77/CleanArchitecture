using System.Collections.Generic;

using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class Country : EntityBase<int>
  {
    public Country()
    {
      CountriesDetails = new HashSet<CountryDetail>();
      Customers = new HashSet<Customer>();
      Stores = new HashSet<Store>();
      Suppliers = new HashSet<Supplier>();
      Users = new HashSet<User>();
    }

    public string Iso { get; set; }
    public string NameCountry { get; set; }
    public string Nicename { get; set; }
    public string Iso3 { get; set; }
    public short? Numcode { get; set; }
    public int Phonecode { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual ICollection<CountryDetail> CountriesDetails { get; set; }
    public virtual ICollection<Customer> Customers { get; set; }
    public virtual ICollection<Store> Stores { get; set; }
    public virtual ICollection<Supplier> Suppliers { get; set; }
    public virtual ICollection<User> Users { get; set; }
  }
}

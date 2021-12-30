using System.Collections.Generic;

using CA.Core.Entities.Base;

namespace CA.Core.Entities
{
  public partial class Supplier : EntityBase<int>
  {
    public Supplier()
    {
      Articles = new HashSet<Article>();
      StockInventories = new HashSet<StockInventory>();
      Brands = new HashSet<Brand>();
    }

    public string Name { get; set; }
    public string Address { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual ICollection<Article> Articles { get; set; }
    public virtual ICollection<Brand> Brands { get; set; }
    public virtual ICollection<StockInventory> StockInventories { get; set; }
  }
}

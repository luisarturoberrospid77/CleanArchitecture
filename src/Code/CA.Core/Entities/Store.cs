using System.Collections.Generic;

using CA.Core.Entities.Base;

namespace CA.Core.Entities
{
  public partial class Store : EntityBase<int>
  {
    public Store()
    {
      Orders = new HashSet<Order>();
      StockInventoryOriginStores = new HashSet<StockInventory>();
      StockInventoryPostingStores = new HashSet<StockInventory>();
    }

    public string Name { get; set; }
    public string Address { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<StockInventory> StockInventoryOriginStores { get; set; }
    public virtual ICollection<StockInventory> StockInventoryPostingStores { get; set; }
  }
}

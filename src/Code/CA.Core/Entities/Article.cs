using System.Collections.Generic;

using CA.Core.Entities.Base;

namespace CA.Core.Entities
{
  public partial class Article : EntityBase<int>
  {
    public Article()
    {
      OrderDetails = new HashSet<OrderDetail>();
      StockInventories = new HashSet<StockInventory>();
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int TotalInVault { get; set; }
    public int DepartamentId { get; set; }
    public int ProducttypeId { get; set; }
    public int SupplierId { get; set; }
    public int BrandId { get; set; }
    public string ImageArticle { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual Brand Brands { get; set; }
    public virtual Supplier Suppliers { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    public virtual ICollection<StockInventory> StockInventories { get; set; }
  }
}

using System;

namespace CA.Core.Entities
{
  public partial class OrderDetail
  {
    public int RowId { get; set; }
    public int OrderId { get; set; }
    public int SkuId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal ValueTax { get; set; }
    public decimal TotalValue { get; set; }
    public bool? Issystemrow { get; set; }
    public bool Isdeleted { get; set; }
    public DateTime Creationdate { get; set; }
    public int AccountIdCreationdate { get; set; }
    public DateTime? Updatedate { get; set; }
    public int? AccountIdUpdatedate { get; set; }
    public DateTime? Deletedate { get; set; }
    public int? AccountIdDeletedate { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual Order Orders { get; set; }
    public virtual Article Skus { get; set; }
  }
}

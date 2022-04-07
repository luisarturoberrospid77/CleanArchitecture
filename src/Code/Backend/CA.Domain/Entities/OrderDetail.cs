using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class OrderDetail : EntityBase<int>
  {
    public int OrderId { get; set; }
    public int SkuId { get; set; }
    public int Quantity { get; set; }
    public decimal SalePrice { get; set; }
    public decimal SaleSubTotal { get; set; }
    public decimal SaleTax { get; set; }
    public decimal SaleGrandTotal { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual Order Order { get; set; }
    public virtual Article Sku { get; set; }
  }
}

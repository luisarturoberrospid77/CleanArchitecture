using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class AssignmentDetail : EntityBase<int>
  {
    public int AssignmentId { get; set; }
    public int SkuId { get; set; }
    public int Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal PurchaseSubTotal { get; set; }
    public decimal PurchaseTax { get; set; }
    public decimal PurchaseGrandTotal { get; set; }
    public decimal SalePrice { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual Assignment Assignment { get; set; }
    public virtual Article Sku { get; set; }
  }
}

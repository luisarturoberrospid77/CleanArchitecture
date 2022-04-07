using System.Collections.Generic;

using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class Purchase : EntityBase<int>
  {
    public Purchase()
    {
      PurchaseDetails = new HashSet<PurchaseDetail>();
    }

    public int SupplierId { get; set; }
    public int Quantity { get; set; }
    public decimal PurchaseSubTotal { get; set; }
    public decimal PurchaseTax { get; set; }
    public decimal PurchaseGrandTotal { get; set; }
    public string Comments { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual Supplier Supplier { get; set; }
    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
  }
}

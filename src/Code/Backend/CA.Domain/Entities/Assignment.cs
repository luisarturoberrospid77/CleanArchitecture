using System.Collections.Generic;

using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class Assignment : EntityBase<int>
  {
    public Assignment()
    {
      AssignmentDetails = new HashSet<AssignmentDetail>();
    }

    public int StoreId { get; set; }
    public int Quantity { get; set; }
    public decimal PurchaseSubTotal { get; set; }
    public decimal PurchaseTax { get; set; }
    public decimal PurchaseGrandTotal { get; set; }
    public string Comments { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual Store Store { get; set; }
    public virtual ICollection<AssignmentDetail> AssignmentDetails { get; set; }
  }
}

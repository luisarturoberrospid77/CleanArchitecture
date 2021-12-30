using System.Collections.Generic;

using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class Order : EntityBase<int>
  {
    public Order()
    {
      OrderDetails = new HashSet<OrderDetail>();
    }

    public int CustomerId { get; set; }
    public int StoreId { get; set; }
    public int StatusOrder { get; set; }
    public int TypeOrder { get; set; }
    public int Quantity { get; set; }
    public decimal SalePrice { get; set; }
    public decimal SaleSubTotal { get; set; }
    public decimal SaleTax { get; set; }
    public decimal SaleGrandTotal { get; set; }
    public string Comments { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Store Store { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
  }
}

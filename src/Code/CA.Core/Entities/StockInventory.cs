using System;

namespace CA.Core.Entities
{
  public partial class StockInventory
  {
    public int Id { get; set; }
    public int SkuId { get; set; }
    public int OriginStoreId { get; set; }
    public int StartingTotal { get; set; }
    public decimal PriceOrigin { get; set; }
    public int SupplierId { get; set; }
    public int PostingStoreId { get; set; }
    public int FinalTotal { get; set; }
    public decimal PricePosting { get; set; }
    public int MovementStatus { get; set; }
    public string Comments { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public bool? Issystemrow { get; set; }
    public bool Isdeleted { get; set; }
    public DateTime Creationdate { get; set; }
    public int AccountIdCreationdate { get; set; }
    public DateTime? Updatedate { get; set; }
    public int? AccountIdUpdatedate { get; set; }
    public DateTime? Deletedate { get; set; }
    public int? AccountIdDeletedate { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual Store OriginStores { get; set; }
    public virtual Store PostingStores { get; set; }
    public virtual Article Skus { get; set; }
    public virtual Supplier Suppliers { get; set; }
  }
}

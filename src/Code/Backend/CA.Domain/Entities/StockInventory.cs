using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
    public partial class StockInventory : EntityBase<int>
    {
        public int SkuId { get; set; }
        public int StoreId { get; set; }
        public int ItemInputQuantity { get; set; }
        public int ItemOutputQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }

        public virtual User AccountIdCreationdateNavigation { get; set; }
        public virtual Article Sku { get; set; }
        public virtual Store Store { get; set; }
    }
}

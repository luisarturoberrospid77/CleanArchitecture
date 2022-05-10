using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
    public partial class ItemMovement : EntityBase<int>
    {
        public int SkuId { get; set; }
        public int OriginStoreId { get; set; }
        public int StartingTotal { get; set; }
        public int SupplierId { get; set; }
        public int PostingStoreId { get; set; }
        public int FinalTotal { get; set; }
        public int MovementStatus { get; set; }
        public string Comments { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public virtual User AccountIdCreationdateNavigation { get; set; }
        public virtual Store OriginStore { get; set; }
        public virtual Store PostingStore { get; set; }
        public virtual Article Sku { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}

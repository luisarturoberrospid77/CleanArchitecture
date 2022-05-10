using System.Collections.Generic;

using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
    public partial class Article : EntityBase<int>
    {
        public Article()
        {
            AssignmentDetails = new HashSet<AssignmentDetail>();
            ItemMovements = new HashSet<ItemMovement>();
            OrderDetails = new HashSet<OrderDetail>();
            PurchaseDetails = new HashSet<PurchaseDetail>();
            StockArticles = new HashSet<StockInventory>();
        }

        public string ShortName { get; set; }
        public string Description { get; set; }
        public int TotalInVault { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int DepartamentId { get; set; }
        public int ProductTypeId { get; set; }
        public int SupplierId { get; set; }
        public int BrandId { get; set; }
        public string ImageArticle { get; set; }

        public virtual User AccountIdCreationdateNavigation { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<AssignmentDetail> AssignmentDetails { get; set; }
        public virtual ICollection<ItemMovement> ItemMovements { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual ICollection<StockInventory> StockArticles { get; set; }
    }
}

using System;

namespace CA.Domain.DTO
{
    public class PurchaseDetailDTO
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int SkuId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseSubTotal { get; set; }
        public decimal PurchaseTax { get; set; }
        public decimal PurchaseGrandTotal { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsSystemRow { get; set; }
        public int AccountIdCreationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? AccountIdUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? AccountIdDeleteDate { get; set; }
    }
}

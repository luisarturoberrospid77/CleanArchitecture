using System;

namespace CA.Domain.DTO
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SkuId { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public decimal SaleSubTotal { get; set; }
        public decimal SaleTax { get; set; }
        public decimal SaleGrandTotal { get; set; }
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

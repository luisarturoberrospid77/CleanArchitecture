using System;
using System.Collections.Generic;

namespace CA.Domain.DTO
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchaseSubTotal { get; set; }
        public decimal PurchaseTax { get; set; }
        public decimal PurchaseGrandTotal { get; set; }
        public string Comments { get; set; }
        public bool IsSystemRow { get; set; }
        public int AccountIdCreationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? AccountIdUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? AccountIdDeleteDate { get; set; }
        public IEnumerable<PurchaseDetailDTO> PurchaseDetails { get; set; }
    }
}

using System;

namespace CA.Domain.DTO
{
    public class MovementArticleDTO
    {
        public int Id { get; set; }
        public int SkuId { get; set; }
        public string ArticleShortName { get; set; }
        public string Description { get; set; }
        public int OriginStoreId { get; set; }
        public string OriginStoreName { get; set; }
        public int StartingTotal { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int PostingStoreId { get; set; }
        public string PostingStoreName { get; set; }
        public int FinalTotal { get; set; }
        public int MovementStatus { get; set; }
        public string DescriptionMovement { get; set; }
        public string Comments { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
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

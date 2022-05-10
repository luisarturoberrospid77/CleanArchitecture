using System;

namespace CA.Domain.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
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

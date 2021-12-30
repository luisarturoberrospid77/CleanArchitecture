using System;

namespace CA.Domain.DTO
{
  public class StockArticleDTO
  {
    public int Id { get; set; }
    public int SkuId { get; set; }
    public string ArticleShortName { get; set; }
    public string Description { get; set; }
    public int SupplierId { get; set; }
    public string SupplierName { get; set; }
    public int BrandId { get; set; }
    public string BrandName { get; set; }
    public int DepartamentId { get; set; }
    public string DepartmentName { get; set; }
    public int ProducttypeId { get; set; }
    public string ProducttypeName { get; set; }
    public int StoreId { get; set; }
    public string StoreName { get; set; }
    public int ItemInputQuantity { get; set; }
    public int ItemOutputQuantity { get; set; }
    public decimal PurchasePrice { get; set; }
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

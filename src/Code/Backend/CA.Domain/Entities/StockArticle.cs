using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class StockArticle : EntityBase<int>
  {
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
  }
}

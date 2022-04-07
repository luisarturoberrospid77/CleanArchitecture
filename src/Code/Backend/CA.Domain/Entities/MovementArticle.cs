using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class MovementArticle : EntityBase<int>
  {
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
  }
}

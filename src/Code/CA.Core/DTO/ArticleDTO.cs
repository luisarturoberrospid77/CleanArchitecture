using System;

namespace CA.Core.DTO
{
  public class ArticleDTO
  {
    public int SkuId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int TotalInShelf { get; set; }
    public int TotalInVault { get; set; }
    public int ProducttypeId { get; set; }
    public int StoreId { get; set; }
    public int AccountId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
  }
}

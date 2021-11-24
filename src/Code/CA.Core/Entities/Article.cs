using System;

namespace CA.Core.Entities
{
  public partial class Article
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
    public DateTime Creationdate { get; set; }
    public DateTime? Updatedate { get; set; }

    public virtual User Account { get; set; }
    public virtual ProductType Producttype { get; set; }
    public virtual Store Store { get; set; }
  }
}

namespace CA.Core.DTO
{
  public class CreateArticleDTO
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int TotalInVault { get; set; }
    public int DepartamentId { get; set; }
    public int ProducttypeId { get; set; }
    public int SupplierId { get; set; }
    public int BrandId { get; set; }
    public string ImageArticle { get; set; }
    public int AccountIdCreationDate { get; set; }
  }
}

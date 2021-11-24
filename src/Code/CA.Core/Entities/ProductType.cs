using System;
using System.Collections.Generic;

namespace CA.Core.Entities
{
  public partial class ProductType
  {
    public ProductType()
    {
      MtArticles = new HashSet<Article>();
    }

    public int ProducttypeId { get; set; }
    public string Description { get; set; }
    public int AccountId { get; set; }
    public DateTime Creationdate { get; set; }
    public DateTime? Updatedate { get; set; }

    public virtual User Account { get; set; }
    public virtual ICollection<Article> MtArticles { get; set; }
  }
}

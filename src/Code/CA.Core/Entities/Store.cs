using System;
using System.Collections.Generic;

namespace CA.Core.Entities
{
  public partial class Store
  {
    public Store()
    {
      MtArticles = new HashSet<Article>();
    }
    public int StoreId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int AccountId { get; set; }
    public DateTime Creationdate { get; set; }
    public DateTime? Updatedate { get; set; }
    public virtual User Account { get; set; }
    public virtual ICollection<Article> MtArticles { get; set; }
  }
}

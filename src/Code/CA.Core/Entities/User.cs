using System;
using System.Collections.Generic;

namespace CA.Core.Entities
{
  public partial class User
  {
    public User()
    {
      MtArticles = new HashSet<Article>();
      MtProductTypes = new HashSet<ProductType>();
      MtStores = new HashSet<Store>();
    }

    public int AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Passwordhash { get; set; }
    public DateTime Creationdate { get; set; }
    public DateTime? Updatedate { get; set; }

    public virtual ICollection<Article> MtArticles { get; set; }
    public virtual ICollection<ProductType> MtProductTypes { get; set; }
    public virtual ICollection<Store> MtStores { get; set; }
  }
}

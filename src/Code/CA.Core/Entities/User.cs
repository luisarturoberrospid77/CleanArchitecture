using System;
using System.Collections.Generic;

namespace CA.Core.Entities
{
  public partial class User
  {
    public User()
    {
      Articles = new HashSet<Article>();
      Brands = new HashSet<Brand>();
      CodeNamespaces = new HashSet<CodeNamespace>();
      CodeValues = new HashSet<CodeValue>();
      OrderDetails = new HashSet<OrderDetail>();
      Orders = new HashSet<Order>();
      StockInventories = new HashSet<StockInventory>();
      Stores = new HashSet<Store>();
      Suppliers = new HashSet<Supplier>();
    }

    public int AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Passwordhash { get; set; }
    public string Email { get; set; }
    public int NumberOfAttemps { get; set; }
    public int StatusAccount { get; set; }
    public int RoleId { get; set; }
    public bool? Issystemrow { get; set; }
    public bool Isdeleted { get; set; }
    public DateTime Creationdate { get; set; }
    public int AccountIdCreationdate { get; set; }
    public DateTime? Updatedate { get; set; }
    public int? AccountIdUpdatedate { get; set; }
    public DateTime? Deletedate { get; set; }
    public int? AccountIdDeletedate { get; set; }

    public virtual ICollection<Article> Articles { get; set; }
    public virtual ICollection<Brand> Brands { get; set; }
    public virtual ICollection<CodeNamespace> CodeNamespaces { get; set; }
    public virtual ICollection<CodeValue> CodeValues { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<StockInventory> StockInventories { get; set; }
    public virtual ICollection<Store> Stores { get; set; }
    public virtual ICollection<Supplier> Suppliers { get; set; }
  }
}

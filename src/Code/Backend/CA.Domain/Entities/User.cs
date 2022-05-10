using System.Collections.Generic;

using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
    public partial class User : EntityBase<int>
    {
        public User()
        {
            Articles = new HashSet<Article>();
            AssignmentDetails = new HashSet<AssignmentDetail>();
            Assignments = new HashSet<Assignment>();
            Brands = new HashSet<Brand>();
            CodeNamespaces = new HashSet<CodeNamespace>();
            CodeValues = new HashSet<CodeValue>();
            Countries = new HashSet<Country>();
            CountriesDetails = new HashSet<CountryDetail>();
            Customers = new HashSet<Customer>();
            ItemMovements = new HashSet<ItemMovement>();
            OrderDetails = new HashSet<OrderDetail>();
            Orders = new HashSet<Order>();
            PurchaseDetails = new HashSet<PurchaseDetail>();
            Purchases = new HashSet<Purchase>();
            StockArticles = new HashSet<StockInventory>();
            Stores = new HashSet<Store>();
            Suppliers = new HashSet<Supplier>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Passwordhash { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string Adress { get; set; }
        public int PostalCode { get; set; }
        public int CountryCode { get; set; }
        public int FederalEntityCode { get; set; }
        public int MunicipalityCode { get; set; }
        public int NeighborhoodCode { get; set; }
        public int NumberOfAttemps { get; set; }
        public int StatusAccount { get; set; }
        public int RoleId { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<AssignmentDetail> AssignmentDetails { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<CodeNamespace> CodeNamespaces { get; set; }
        public virtual ICollection<CodeValue> CodeValues { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<CountryDetail> CountriesDetails { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<ItemMovement> ItemMovements { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<StockInventory> StockArticles { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}

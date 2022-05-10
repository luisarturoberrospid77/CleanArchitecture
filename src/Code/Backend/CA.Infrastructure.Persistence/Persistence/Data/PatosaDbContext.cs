using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure.Persistence.Data
{
    public partial class PatosaDbContext : DbContext
    {
        public PatosaDbContext() : base() { }
        public PatosaDbContext(DbContextOptions<PatosaDbContext> options) : base(options) { }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<AssignmentDetail> AssignmentDetails { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CodeNamespace> CodeNamespaces { get; set; }
        public virtual DbSet<CodeValue> CodeValues { get; set; }
        public virtual DbSet<CountryDetail> CountryDetails { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ItemMovement> ItemMovements { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<StockInventory> StockArticlesInventory { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<MenuCategory> MenuCategories { get; set; }
        public virtual DbSet<MenuSystem> MenuSystems { get; set; }
        public virtual DbSet<MovementArticle> MovementArticles { get; set; }
        public virtual DbSet<StockArticle> StockArticles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
          modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatosaDbContext).Assembly);
    }
}

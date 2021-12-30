using Microsoft.EntityFrameworkCore;

using CA.Core.Entities;

namespace CA.Infrastructure.Persistence.Data
{
  public partial class PatosaDbContext : DbContext
  {
    public PatosaDbContext() : base() { }
    public PatosaDbContext(DbContextOptions<PatosaDbContext> options) : base(options) { }

    public virtual DbSet<Article> Articles { get; set; }
    public virtual DbSet<Brand> Brands { get; set; }
    public virtual DbSet<CodeNamespace> CodeNamespaces { get; set; }
    public virtual DbSet<CodeValue> CodeValues { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }
    public virtual DbSet<StockInventory> StockInventories { get; set; }
    public virtual DbSet<Store> Stores { get; set; }
    public virtual DbSet<Supplier> Suppliers { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<MenuCategory> MenuCategories { get; set; }
    public virtual DbSet<MenuSystem> MenuSystems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatosaDbContext).Assembly);
  }
}

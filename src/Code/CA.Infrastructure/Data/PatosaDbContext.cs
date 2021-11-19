using Microsoft.EntityFrameworkCore;

using CA.Core.Entities;

namespace CA.Infrastructure.Data
{
  public partial class PatosaDbContext : DbContext
  {
    public PatosaDbContext() { }

    public PatosaDbContext(DbContextOptions<PatosaDbContext> options) : base(options) { }

    public virtual DbSet<Article> Articles { get; set; }
    public virtual DbSet<ProductType> ProductTypes { get; set; }
    public virtual DbSet<Store> Stores { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatosaDbContext).Assembly);
    }
  }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CA.Core.Entities;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class OrderConfiguration : IEntityTypeConfiguration<Order>
  {
    public void Configure(EntityTypeBuilder<Order> builder)
    {
      builder.ToTable("mtOrders");

      builder.HasKey(e => e.OrderId).HasName("pk_OrderHeader");
      builder.HasIndex(e => new { e.OrderId, e.StoreId }, "uq_OrderHeader1").IsUnique();
      builder.Property(e => e.OrderId).HasColumnName("order_id");
      builder.Property(e => e.AccountIdCreationdate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeletedate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdatedate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.Comments).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("comments");
      builder.Property(e => e.Creationdate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.Deletedate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.Isdeleted).HasColumnName("isdeleted");
      builder.Property(e => e.Issystemrow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.StatusOrder).HasColumnName("status_order");
      builder.Property(e => e.StoreId).HasColumnName("store_id");
      builder.Property(e => e.TypeOrder).HasColumnName("type_order");
      builder.Property(e => e.Updatedate).HasColumnType("datetime").HasColumnName("updatedate");

      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.Orders)
             .HasForeignKey(d => d.AccountIdCreationdate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_OrderHeader2");

      builder.HasOne(d => d.Stores)
             .WithMany(p => p.Orders)
             .HasForeignKey(d => d.StoreId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_OrderHeader3");
    }
  }
}

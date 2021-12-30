using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CA.Core.Entities;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
  {
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
      builder.ToTable("mtOrderDetail");

      builder.HasKey(e => e.RowId).HasName("pk_OrderDetail");
      builder.HasIndex(e => new { e.RowId, e.OrderId }, "uq_OrderDetail").IsUnique();
      builder.Property(e => e.RowId).HasColumnName("row_id");
      builder.Property(e => e.AccountIdCreationdate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeletedate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdatedate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.Creationdate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.Deletedate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.Isdeleted).HasColumnName("isdeleted");
      builder.Property(e => e.Issystemrow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.OrderId).HasColumnName("order_id");
      builder.Property(e => e.Price).HasColumnType("money").HasColumnName("price");
      builder.Property(e => e.Quantity).HasColumnName("quantity");
      builder.Property(e => e.SkuId).HasColumnName("sku_id");
      builder.Property(e => e.TotalValue).HasColumnType("money").HasColumnName("total_value");
      builder.Property(e => e.Updatedate).HasColumnType("datetime").HasColumnName("updatedate");
      builder.Property(e => e.ValueTax).HasColumnType("money").HasColumnName("value_tax");

      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.OrderDetails)
             .HasForeignKey(d => d.AccountIdCreationdate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_OrderDetail1");

      builder.HasOne(d => d.Orders)
             .WithMany(p => p.OrderDetails)
             .HasForeignKey(d => d.OrderId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_OrderDetail2");

      builder.HasOne(d => d.Skus)
             .WithMany(p => p.OrderDetails)
             .HasForeignKey(d => d.SkuId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_OrderDetail3");
    }
  }
}

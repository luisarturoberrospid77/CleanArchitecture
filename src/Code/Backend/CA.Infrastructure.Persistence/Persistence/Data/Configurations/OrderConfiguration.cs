using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class OrderConfiguration : IEntityTypeConfiguration<Order>
  {
    public void Configure(EntityTypeBuilder<Order> builder)
    {
      builder.ToTable("mtOrders");

      builder.HasKey(e => e.Id).HasName("pk_OrderHeader");
      builder.HasIndex(e => new { e.Id, e.StoreId, e.CustomerId }, "uq_OrderHeader1").IsUnique();

      builder.Property(e => e.Id).HasColumnName("order_id");
      builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.Comments).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("comments");
      builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.CustomerId).HasColumnName("customer_id");
      builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
      builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.Quantity).HasColumnName("quantity");
      builder.Property(e => e.SaleGrandTotal).HasColumnType("decimal(15, 2)").HasColumnName("sale_grand_total");
      builder.Property(e => e.SalePrice).HasColumnType("decimal(15, 2)").HasColumnName("sale_price");
      builder.Property(e => e.SaleSubTotal).HasColumnType("decimal(15, 2)").HasColumnName("sale_sub_total");
      builder.Property(e => e.SaleTax).HasColumnType("decimal(15, 2)").HasColumnName("sale_tax");
      builder.Property(e => e.StatusOrder).HasColumnName("status_order");
      builder.Property(e => e.StoreId).HasColumnName("store_id");
      builder.Property(e => e.TypeOrder).HasColumnName("type_order");
      builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.Orders)
             .HasForeignKey(d => d.AccountIdCreationDate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_OrderHeader2");

      builder.HasOne(d => d.Customer)
             .WithMany(p => p.Orders)
             .HasForeignKey(d => d.CustomerId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_OrderHeader4");

      builder.HasOne(d => d.Store)
             .WithMany(p => p.Orders)
             .HasForeignKey(d => d.StoreId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_OrderHeader3");
    }
  }
}
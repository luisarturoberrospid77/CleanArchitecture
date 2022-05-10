using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("mtOrderDetail");

            builder.HasKey(e => new { e.Id, e.OrderId, e.SkuId }).HasName("pk_OrderDetail");
            builder.HasIndex(e => new { e.Id, e.OrderId, e.SkuId }, "uq_OrderDetail").IsUnique();

            builder.Property(e => e.Id).HasColumnName("row_id");
            builder.Property(e => e.OrderId).HasColumnName("order_id");
            builder.Property(e => e.SkuId).HasColumnName("sku_id");
            builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
            builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
            builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
            builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
            builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
            builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
            builder.Property(e => e.Quantity).HasColumnName("quantity");
            builder.Property(e => e.SaleGrandTotal).HasColumnType("decimal(15, 2)").HasColumnName("sale_grand_total");
            builder.Property(e => e.SalePrice).HasColumnType("decimal(15, 2)").HasColumnName("sale_price");
            builder.Property(e => e.SaleSubTotal).HasColumnType("decimal(15, 2)").HasColumnName("sale_sub_total");
            builder.Property(e => e.SaleTax).HasColumnType("decimal(15, 2)").HasColumnName("sale_tax");
            builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

            builder.HasOne(d => d.AccountIdCreationdateNavigation)
                   .WithMany(p => p.OrderDetails)
                   .HasForeignKey(d => d.AccountIdCreationDate)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_OrderDetail1");

            builder.HasOne(d => d.Order)
                   .WithMany(p => p.OrderDetails)
                   .HasForeignKey(d => d.OrderId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_OrderDetail2");

            builder.HasOne(d => d.Sku)
                   .WithMany(p => p.OrderDetails)
                   .HasForeignKey(d => d.SkuId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_OrderDetail3");
        }
    }
}

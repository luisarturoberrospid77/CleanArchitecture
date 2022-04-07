using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class PurchaseDetailConfiguration : IEntityTypeConfiguration<PurchaseDetail>
  {
    public void Configure(EntityTypeBuilder<PurchaseDetail> builder)
    {
      builder.ToTable("mtPurchaseDetail");

      builder.HasKey(e => new { e.Id, e.PurchaseId, e.SkuId }).HasName("pk_PurchaseDetail");
      builder.HasIndex(e => new { e.Id, e.PurchaseId, e.SkuId }, "uq_PurchaseDetail").IsUnique();

      builder.Property(e => e.Id).HasColumnName("row_id");
      builder.Property(e => e.PurchaseId).HasColumnName("purchase_id");
      builder.Property(e => e.SkuId).HasColumnName("sku_id");
      builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
      builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.PurchaseGrandTotal).HasColumnType("decimal(15, 2)").HasColumnName("purchase_grand_total");
      builder.Property(e => e.PurchasePrice).HasColumnType("decimal(15, 2)").HasColumnName("purchase_price");
      builder.Property(e => e.PurchaseSubTotal).HasColumnType("decimal(15, 2)").HasColumnName("purchase_sub_total");
      builder.Property(e => e.PurchaseTax).HasColumnType("decimal(15, 2)").HasColumnName("purchase_tax");
      builder.Property(e => e.Quantity).HasColumnName("quantity");
      builder.Property(e => e.SalePrice).HasColumnType("decimal(15, 2)").HasColumnName("sale_price");
      builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.PurchaseDetails)
             .HasForeignKey(d => d.AccountIdCreationDate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_PurchaseDetail1");

      builder.HasOne(d => d.Purchase)
             .WithMany(p => p.PurchaseDetails)
             .HasForeignKey(d => d.PurchaseId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_PurchaseDetail3");

      builder.HasOne(d => d.Sku)
             .WithMany(p => p.PurchaseDetails)
             .HasForeignKey(d => d.SkuId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_PurchaseDetail2");
    }
  }
}
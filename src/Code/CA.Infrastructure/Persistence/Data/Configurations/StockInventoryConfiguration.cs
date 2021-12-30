using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CA.Core.Entities;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class StockInventoryConfiguration : IEntityTypeConfiguration<StockInventory>
  {
    public void Configure(EntityTypeBuilder<StockInventory> builder)
    {
      builder.ToTable("mtStockInventory");

      builder.HasIndex(e => new { e.Id, e.OriginStoreId, e.PostingStoreId, e.MovementStatus }, "uq_StockInventory").IsUnique();
      builder.Property(e => e.Id).HasColumnName("id");
      builder.Property(e => e.AccountIdCreationdate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeletedate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdatedate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.Comments).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("comments");
      builder.Property(e => e.Creationdate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.Deletedate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.Isdeleted).HasColumnName("isdeleted");
      builder.Property(e => e.Issystemrow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.MovementStatus).HasColumnName("movement_status");
      builder.Property(e => e.OriginStoreId).HasColumnName("origin_store_id");
      builder.Property(e => e.PostingStoreId).HasColumnName("posting_store_id");
      builder.Property(e => e.PriceOrigin).HasColumnType("money").HasColumnName("price_origin");
      builder.Property(e => e.PricePosting).HasColumnType("money").HasColumnName("price_posting");
      builder.Property(e => e.SkuId).HasColumnName("sku_id");
      builder.Property(e => e.SupplierId).HasColumnName("supplier_id");
      builder.Property(e => e.StartingTotal).HasColumnName("starting_total");
      builder.Property(e => e.FinalTotal).HasColumnName("final_total");
      builder.Property(e => e.Year).HasColumnName("year");
      builder.Property(e => e.Month).HasColumnName("month");
      builder.Property(e => e.Day).HasColumnName("day");
      builder.Property(e => e.Updatedate).HasColumnType("datetime").HasColumnName("updatedate");

      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.StockInventories)
             .HasForeignKey(d => d.AccountIdCreationdate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_StockInventory1");

      builder.HasOne(d => d.OriginStores)
             .WithMany(p => p.StockInventoryOriginStores)
             .HasForeignKey(d => d.OriginStoreId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_StockInventory3");
 
      builder.HasOne(d => d.PostingStores)
             .WithMany(p => p.StockInventoryPostingStores)
             .HasForeignKey(d => d.PostingStoreId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_StockInventory5");

      builder.HasOne(d => d.Skus)
             .WithMany(p => p.StockInventories)
             .HasForeignKey(d => d.SkuId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_StockInventory2");

      builder.HasOne(d => d.Suppliers)
             .WithMany(p => p.StockInventories)
             .HasForeignKey(d => d.SupplierId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_StockInventory4");
    }
  }
}

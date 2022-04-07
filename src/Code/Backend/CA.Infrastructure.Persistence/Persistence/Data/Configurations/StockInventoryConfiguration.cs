using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class StockInventoryConfiguration : IEntityTypeConfiguration<StockInventory>
  {
    public void Configure(EntityTypeBuilder<StockInventory> builder)
    {
      builder.ToTable("mtStockArticles");

      builder.HasKey(e => new { e.Id, e.SkuId, e.StoreId }).HasName("pk_StockArticle");
      builder.HasIndex(e => new { e.Id, e.SkuId, e.StoreId }, "uq_StockArticle").IsUnique();

      builder.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");
      builder.Property(e => e.SkuId).HasColumnName("sku_id");
      builder.Property(e => e.StoreId).HasColumnName("store_id");
      builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
      builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.ItemInputQuantity).HasColumnName("item_input_quantity");
      builder.Property(e => e.ItemOutputQuantity).HasColumnName("item_output_quantity");
      builder.Property(e => e.PurchasePrice).HasColumnType("decimal(15, 2)").HasColumnName("purchase_price");
      builder.Property(e => e.SalePrice).HasColumnType("decimal(15, 2)").HasColumnName("sale_price");
      builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.StockArticles)
             .HasForeignKey(d => d.AccountIdCreationDate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_StockArticle1");

      builder.HasOne(d => d.Sku)
             .WithMany(p => p.StockArticles)
             .HasForeignKey(d => d.SkuId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_StockArticle2");

      builder.HasOne(d => d.Store)
             .WithMany(p => p.StockArticles)
             .HasForeignKey(d => d.StoreId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_StockArticle3");
    }
  }
}
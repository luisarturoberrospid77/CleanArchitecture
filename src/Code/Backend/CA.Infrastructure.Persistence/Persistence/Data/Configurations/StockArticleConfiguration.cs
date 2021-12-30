using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class StockArticleConfiguration : IEntityTypeConfiguration<StockArticle>
  {
    public void Configure(EntityTypeBuilder<StockArticle> builder)
    {
      builder.ToView("vwStockArticles");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.ArticleShortName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("article_short_name");
      builder.Property(e => e.BrandId).HasColumnName("brand_id");
      builder.Property(e => e.BrandName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("brand_name");
      builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate");
      builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.DepartamentId).HasColumnName("departament_id");
      builder.Property(e => e.DepartmentName).IsRequired().HasMaxLength(100).HasColumnName("department_name");
      builder.Property(e => e.Description).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("description");
      builder.Property(e => e.Id).HasColumnName("id");
      builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
      builder.Property(e => e.IsSystemRow).HasColumnName("issystemrow");
      builder.Property(e => e.ItemInputQuantity).HasColumnName("item_input_quantity");
      builder.Property(e => e.ItemOutputQuantity).HasColumnName("item_output_quantity");
      builder.Property(e => e.ProducttypeId).HasColumnName("producttype_id");
      builder.Property(e => e.ProducttypeName).IsRequired().HasMaxLength(100).HasColumnName("producttype_name");
      builder.Property(e => e.PurchasePrice).HasColumnType("decimal(15, 2)").HasColumnName("purchase_price");
      builder.Property(e => e.SalePrice).HasColumnType("decimal(15, 2)").HasColumnName("sale_price");
      builder.Property(e => e.SkuId).HasColumnName("sku_id");
      builder.Property(e => e.StoreId).HasColumnName("store_id");
      builder.Property(e => e.StoreName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("store_name");
      builder.Property(e => e.SupplierId).HasColumnName("supplier_id");
      builder.Property(e => e.SupplierName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("supplier_name");
      builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");
    }
  }
}
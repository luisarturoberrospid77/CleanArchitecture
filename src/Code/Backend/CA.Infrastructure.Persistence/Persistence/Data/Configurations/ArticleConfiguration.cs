using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class ArticleConfiguration : IEntityTypeConfiguration<Article>
  {
    public void Configure(EntityTypeBuilder<Article> builder)
    {
      builder.ToTable("mtArticles");

      builder.HasKey(e => e.Id).HasName("pk_Idarticle");
      builder.HasIndex(e => new { e.Id, e.DepartamentId, e.ProductTypeId, e.SupplierId, e.BrandId }, "uq_Idarticle").IsUnique();

      builder.Property(e => e.Id).HasColumnName("sku_id");
      builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.BrandId).HasColumnName("brand_id");
      builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.DepartamentId).HasColumnName("departament_id");
      builder.Property(e => e.Description).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("description").HasDefaultValueSql("((0))");
      builder.Property(e => e.ImageArticle).IsUnicode(false).HasColumnName("image_article");
      builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
      builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.ProductTypeId).HasColumnName("producttype_id");
      builder.Property(e => e.PurchasePrice).HasColumnType("decimal(15, 2)").HasColumnName("purchase_price");
      builder.Property(e => e.SalePrice).HasColumnType("decimal(15, 2)").HasColumnName("sale_price");
      builder.Property(e => e.ShortName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("short_name");
      builder.Property(e => e.SupplierId).HasColumnName("supplier_id");
      builder.Property(e => e.TotalInVault).HasColumnName("total_in_vault");
      builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.Articles)
             .HasForeignKey(d => d.AccountIdCreationDate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_Idarticle1");

      builder.HasOne(d => d.Brand)
             .WithMany(p => p.Articles)
             .HasForeignKey(d => d.BrandId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_Idarticle3");

      builder.HasOne(d => d.Supplier)
             .WithMany(p => p.Articles)
             .HasForeignKey(d => d.SupplierId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_Idarticle2");
    }
  }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CA.Core.Entities;

namespace CA.Infrastructure.Data.Configurations
{
  public class ArticleConfiguration : IEntityTypeConfiguration<Article>
  {
    public void Configure(EntityTypeBuilder<Article> builder)
    {
      builder.HasKey(e => e.SkuId)
                  .HasName("pk_Idarticle");

      builder.ToTable("mtArticles");

      builder.HasIndex(e => new { e.SkuId, e.StoreId }, "uq_Idarticle")
          .IsUnique();

      builder.Property(e => e.SkuId).HasColumnName("sku_id");

      builder.Property(e => e.AccountId).HasColumnName("account_id");

      builder.Property(e => e.Creationdate)
          .HasColumnType("datetime")
          .HasColumnName("creationdate")
          .HasDefaultValueSql("(getutcdate())");

      builder.Property(e => e.Description)
          .IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false)
          .HasColumnName("description")
          .HasDefaultValueSql("((0))");

      builder.Property(e => e.Name)
          .IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false)
          .HasColumnName("name");

      builder.Property(e => e.Price)
          .HasColumnType("money")
          .HasColumnName("price");

      builder.Property(e => e.ProducttypeId).HasColumnName("producttype_id");

      builder.Property(e => e.StoreId).HasColumnName("store_id");

      builder.Property(e => e.TotalInShelf).HasColumnName("total_in_shelf");

      builder.Property(e => e.TotalInVault).HasColumnName("total_in_vault");

      builder.Property(e => e.Updatedate)
          .HasColumnType("datetime")
          .HasColumnName("updatedate");

      builder.HasOne(d => d.Account)
          .WithMany(p => p.MtArticles)
          .HasForeignKey(d => d.AccountId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("fk_Idarticle1");

      builder.HasOne(d => d.Producttype)
          .WithMany(p => p.MtArticles)
          .HasForeignKey(d => d.ProducttypeId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("fk_Idarticle3");

      builder.HasOne(d => d.Store)
          .WithMany(p => p.MtArticles)
          .HasForeignKey(d => d.StoreId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("fk_Idarticle2");
    }
  }
}

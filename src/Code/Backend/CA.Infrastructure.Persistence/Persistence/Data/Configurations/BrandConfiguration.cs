using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("mtBrands");

            builder.HasKey(e => e.Id).HasName("pk_IdBrand");
            builder.HasIndex(e => new { e.Id, e.SupplierId, e.AccountIdCreationDate }, "uq_IdBrand").IsUnique();

            builder.Property(e => e.Id).HasColumnName("brand_id");
            builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
            builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
            builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
            builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
            builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
            builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("name");
            builder.Property(e => e.SupplierId).HasColumnName("supplier_id");
            builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

            builder.HasOne(d => d.AccountIdCreationdateNavigation)
                   .WithMany(p => p.Brands)
                   .HasForeignKey(d => d.AccountIdCreationDate)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_IdBrand1");

            builder.HasOne(d => d.Supplier)
                   .WithMany(p => p.Brands)
                   .HasForeignKey(d => d.SupplierId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_IdBrand2");
        }
    }
}

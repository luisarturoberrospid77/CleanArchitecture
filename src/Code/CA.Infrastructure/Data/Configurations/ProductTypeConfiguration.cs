using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CA.Core.Entities;

namespace CA.Infrastructure.Data.Configurations
{
  public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
  {
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
      builder.HasKey(e => e.ProducttypeId)
                    .HasName("pk_IdProductType");

      builder.ToTable("mtProductTypes");

      builder.HasIndex(e => new { e.ProducttypeId, e.AccountId }, "uq_IdProductType")
          .IsUnique();

      builder.Property(e => e.ProducttypeId).HasColumnName("producttype_id");

      builder.Property(e => e.AccountId).HasColumnName("account_id");

      builder.Property(e => e.Creationdate)
          .HasColumnType("datetime")
          .HasColumnName("creationdate")
          .HasDefaultValueSql("(getutcdate())");

      builder.Property(e => e.Description)
          .IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false)
          .HasColumnName("description");

      builder.Property(e => e.Updatedate)
          .HasColumnType("datetime")
          .HasColumnName("updatedate");

      builder.HasOne(d => d.Account)
          .WithMany(p => p.MtProductTypes)
          .HasForeignKey(d => d.AccountId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("fk_IdProductType");
    }
  }
}

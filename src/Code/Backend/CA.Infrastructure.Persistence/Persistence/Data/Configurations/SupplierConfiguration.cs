using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
  {
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
      builder.ToTable("mtSuppliers");

      builder.HasKey(e => e.Id).HasName("pk_IdSupplier");
      builder.HasIndex(e => new { e.Id, e.AccountIdCreationDate }, "uq_IdSupplier").IsUnique();

      builder.Property(e => e.Id).HasColumnName("supplier_id");
      builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.Address).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("address").HasDefaultValueSql("((0))");
      builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.CountryCode).HasColumnName("country_code");
      builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.Email).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("email");
      builder.Property(e => e.FederalEntityCode).HasColumnName("federal_entity_code");
      builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
      builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.MunicipalityCode).HasColumnName("municipality_code");
      builder.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("name");
      builder.Property(e => e.NeighborhoodCode).HasColumnName("neighborhood_code");
      builder.Property(e => e.NumberPhone).IsRequired().HasMaxLength(50).IsUnicode(false).HasColumnName("number_phone");
      builder.Property(e => e.PostalCode).HasColumnName("postal_code");
      builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.Suppliers)
             .HasForeignKey(d => d.AccountIdCreationDate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_IdSupplier1");

      builder.HasOne(d => d.CountryCodeNavigation)
             .WithMany(p => p.Suppliers)
             .HasForeignKey(d => d.CountryCode)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_IdSupplier2");
    }
  }
}
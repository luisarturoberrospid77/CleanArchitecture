using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
  {
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
      builder.ToTable("mtCustomers");

      builder.HasKey(e => e.Id).HasName("pk_IdCustomer");
      builder.HasIndex(e => new { e.Id, e.AccountIdCreationDate }, "uq_IdCustomer").IsUnique();

      builder.Property(e => e.Id).HasColumnName("customer_id");
      builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.Address).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("address").HasDefaultValueSql("((0))");
      builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.CountryCode).HasColumnName("country_code");
      builder.Property(e => e.CurpCode).HasMaxLength(50).IsUnicode(false).HasColumnName("curp_code");
      builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.Email).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("email");
      builder.Property(e => e.FederalEntityCode).HasColumnName("federal_entity_code");
      builder.Property(e => e.FirstName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("first_name");
      builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
      builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.LastName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("last_name");
      builder.Property(e => e.MunicipalityCode).HasColumnName("municipality_code");
      builder.Property(e => e.NeighborhoodCode).HasColumnName("neighborhood_code");
      builder.Property(e => e.NumberPhone).IsRequired().HasMaxLength(50).IsUnicode(false).HasColumnName("number_phone");
      builder.Property(e => e.PostalCode).HasColumnName("postal_code");
      builder.Property(e => e.RfcCode).HasMaxLength(50).IsUnicode(false).HasColumnName("rfc_code");
      builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.Customers)
             .HasForeignKey(d => d.AccountIdCreationDate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_IdCustomer1");

      builder.HasOne(d => d.CountryCodeNavigation)
             .WithMany(p => p.Customers)
             .HasForeignKey(d => d.CountryCode)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_IdCustomer2");
    }
  }
}
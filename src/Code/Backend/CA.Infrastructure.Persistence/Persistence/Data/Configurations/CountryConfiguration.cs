using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class CountryConfiguration : IEntityTypeConfiguration<Country>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Country> builder)
    {
      builder.ToTable("mtCountries");

      builder.HasKey(e => e.Id).HasName("pk_IdCountry");
      builder.HasIndex(e => new { e.Id, e.Iso, e.NameCountry, e.Nicename, e.Iso3, e.Numcode, e.Phonecode }, "uq_IdCountry").IsUnique();

      builder.Property(e => e.Id).HasColumnName("country_code");
      builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
      builder.Property(e => e.Iso).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("iso").IsFixedLength(true);
      builder.Property(e => e.Iso3).HasMaxLength(3).IsUnicode(false).HasColumnName("iso3").IsFixedLength(true);
      builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.NameCountry).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("name_country");
      builder.Property(e => e.Nicename).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("nicename");
      builder.Property(e => e.Numcode).HasColumnName("numcode");
      builder.Property(e => e.Phonecode).HasColumnName("phonecode");
      builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.Countries)
             .HasForeignKey(d => d.AccountIdCreationDate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_IdCountry1");
    }
  }
}
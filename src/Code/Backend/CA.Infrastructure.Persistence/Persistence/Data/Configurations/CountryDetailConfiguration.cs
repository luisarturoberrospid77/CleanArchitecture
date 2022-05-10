using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
    public class CountryDetailConfiguration : IEntityTypeConfiguration<CountryDetail>
    {
        public void Configure(EntityTypeBuilder<CountryDetail> builder)
        {
            builder.ToTable("mtCountriesDetail");

            builder.HasKey(e => new { e.Id, e.CountryCode, e.FederalEntityCode, e.MunicipalityCode, e.PostalCode, e.TownshipId, e.TownshipTypeId }).HasName("pk_IdPostalCode");
            builder.HasIndex(e => new { e.Id, e.CountryCode, e.FederalEntityCode, e.MunicipalityCode, e.PostalCode, e.TownshipId, e.TownshipTypeId }, "uq_IdPostalCode").IsUnique();

            builder.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("postalcode_id");
            builder.Property(e => e.CountryCode).HasColumnName("country_code");
            builder.Property(e => e.FederalEntityCode).HasColumnName("federal_entity_code");
            builder.Property(e => e.MunicipalityCode).HasColumnName("municipality_code");
            builder.Property(e => e.PostalCode).HasColumnName("postal_code");
            builder.Property(e => e.TownshipId).HasColumnName("township_id");
            builder.Property(e => e.TownshipTypeId).HasColumnName("township_type_id");
            builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
            builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
            builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
            builder.Property(e => e.CityName).HasMaxLength(255).IsUnicode(false).HasColumnName("city_name");
            builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
            builder.Property(e => e.FederalEntityName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("federal_entity_name");
            builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
            builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
            builder.Property(e => e.MunicipalityName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("municipality_name");
            builder.Property(e => e.TownshipName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("township_name");
            builder.Property(e => e.TownshipTypeName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("township_type_name");
            builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");
            builder.Property(e => e.ZoneName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("zone_name");

            builder.HasOne(d => d.AccountIdCreationdateNavigation)
                   .WithMany(p => p.CountriesDetails)
                   .HasForeignKey(d => d.AccountIdCreationDate)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_IdPostalCode2");

            builder.HasOne(d => d.CountryCodeNavigation)
                   .WithMany(p => p.CountriesDetails)
                   .HasForeignKey(d => d.CountryCode)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_IdPostalCode1");
        }
    }
}

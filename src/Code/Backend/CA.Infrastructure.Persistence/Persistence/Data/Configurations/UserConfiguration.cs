using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("mtUsers");

            builder.HasKey(e => e.Id).HasName("pk_IdUser");
            builder.HasIndex(e => new { e.Id, e.StatusAccount, e.RoleId }, "uq_IdUser").IsUnique();

            builder.Property(e => e.Id).HasColumnName("account_id");
            builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
            builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
            builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
            builder.Property(e => e.Adress).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("adress");
            builder.Property(e => e.CountryCode).HasColumnName("country_code");
            builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
            builder.Property(e => e.Email).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("email");
            builder.Property(e => e.FederalEntityCode).HasColumnName("federal_entity_code");
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("first_name");
            builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
            builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("last_name");
            builder.Property(e => e.MunicipalityCode).HasColumnName("municipality_code");
            builder.Property(e => e.NeighborhoodCode).HasColumnName("neighborhood_code");
            builder.Property(e => e.NumberOfAttemps).HasColumnName("number_of_attemps");
            builder.Property(e => e.NumberPhone).IsRequired().HasMaxLength(50).IsUnicode(false).HasColumnName("number_phone");
            builder.Property(e => e.Passwordhash).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("passwordhash");
            builder.Property(e => e.PostalCode).HasColumnName("postal_code");
            builder.Property(e => e.RoleId).HasColumnName("role_id");
            builder.Property(e => e.StatusAccount).HasColumnName("status_account");
            builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");
            builder.Property(e => e.Username).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("username");

            builder.HasOne(d => d.CountryCodeNavigation)
                   .WithMany(p => p.Users)
                   .HasForeignKey(d => d.CountryCode)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_IdUser1");
        }
    }
}

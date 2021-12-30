using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CA.Core.Entities;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("mtUsers");

      builder.HasKey(e => e.AccountId).HasName("pk_IdUser");
      builder.HasIndex(e => new { e.AccountId, e.StatusAccount, e.RoleId }, "uq_IdUser").IsUnique();
      builder.Property(e => e.AccountId).HasColumnName("account_id");
      builder.Property(e => e.AccountIdCreationdate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeletedate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdatedate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.Creationdate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.Deletedate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.Email).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("email");
      builder.Property(e => e.FirstName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("first_name");
      builder.Property(e => e.Isdeleted).HasColumnName("isdeleted");
      builder.Property(e => e.Issystemrow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.LastName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("last_name");
      builder.Property(e => e.NumberOfAttemps).HasColumnName("number_of_attemps");
      builder.Property(e => e.Passwordhash).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("passwordhash");
      builder.Property(e => e.RoleId).HasColumnName("role_id");
      builder.Property(e => e.StatusAccount).HasColumnName("status_account");
      builder.Property(e => e.Updatedate).HasColumnType("datetime").HasColumnName("updatedate");
      builder.Property(e => e.Username).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("username");
    }
  }
}

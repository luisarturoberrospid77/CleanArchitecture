using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CA.Core.Entities;

namespace CA.Infrastructure.Data.Configurations
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(e => e.AccountId)
                    .HasName("pk_IdUser");

      builder.ToTable("mtUsers");

      builder.HasIndex(e => e.AccountId, "uq_IdUser")
          .IsUnique();

      builder.Property(e => e.AccountId).HasColumnName("account_id");

      builder.Property(e => e.Creationdate)
                      .HasColumnType("datetime")
                      .HasColumnName("creationdate")
                      .HasDefaultValueSql("(getutcdate())");

      builder.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(255)
                      .IsUnicode(false)
                      .HasColumnName("first_name");

      builder.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(255)
                      .IsUnicode(false)
                      .HasColumnName("last_name");

      builder.Property(e => e.Passwordhash)
                      .IsRequired()
                      .HasMaxLength(255)
                      .IsUnicode(false)
                      .HasColumnName("passwordhash");

      builder.Property(e => e.Updatedate)
                      .HasColumnType("datetime")
                      .HasColumnName("updatedate");

      builder.Property(e => e.Username)
                      .IsRequired()
                      .HasMaxLength(255)
                      .IsUnicode(false)
                      .HasColumnName("username");
    }
  }
}

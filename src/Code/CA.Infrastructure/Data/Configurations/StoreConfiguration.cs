using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CA.Core.Entities;

namespace CA.Infrastructure.Data.Configurations
{
  public class StoreConfiguration : IEntityTypeConfiguration<Store>
  {
    public void Configure(EntityTypeBuilder<Store> builder)
    {
      builder.HasKey(e => e.StoreId)
                    .HasName("pk_IdStore");

      builder.ToTable("mtStores");

      builder.HasIndex(e => new { e.StoreId, e.AccountId }, "uq_IdStore")
          .IsUnique();

      builder.Property(e => e.StoreId).HasColumnName("store_id");

      builder.Property(e => e.AccountId).HasColumnName("account_id");

      builder.Property(e => e.Address)
          .IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false)
          .HasColumnName("address")
          .HasDefaultValueSql("((0))");

      builder.Property(e => e.Creationdate)
          .HasColumnType("datetime")
          .HasColumnName("creationdate")
          .HasDefaultValueSql("(getutcdate())");

      builder.Property(e => e.Name)
          .IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false)
          .HasColumnName("name");

      builder.Property(e => e.Updatedate)
          .HasColumnType("datetime")
          .HasColumnName("updatedate");

      builder.HasOne(d => d.Account)
          .WithMany(p => p.MtStores)
          .HasForeignKey(d => d.AccountId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("fk_IdStore");
    }
  }
}

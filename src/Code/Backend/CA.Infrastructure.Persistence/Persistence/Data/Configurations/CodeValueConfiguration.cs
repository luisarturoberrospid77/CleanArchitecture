using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class CodeValueConfiguration : IEntityTypeConfiguration<CodeValue>
  {
    public void Configure(EntityTypeBuilder<CodeValue> builder)
    {
      builder.ToTable("mtCodeValues");

      builder.HasKey(e => new { e.Id, e.ValueId }).HasName("pk_CodeValue");
      builder.HasIndex(e => new { e.Id, e.CodeNameSpaceId, e.OrderBy, e.ValueId }, "uq_CodeValue").IsUnique();

      builder.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("row_id");
      builder.Property(e => e.ValueId).HasColumnName("value_id");
      builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.CodeNameSpaceId).HasColumnName("codenamespaceid");
      builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.Description).IsRequired().HasMaxLength(100).HasColumnName("description");
      builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
      builder.Property(e => e.IsRoot).HasColumnName("isroot");
      builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.OrderBy).HasColumnName("orderby");
      builder.Property(e => e.ParentId).HasColumnName("parentid");
      builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.CodeValues)
             .HasForeignKey(d => d.AccountIdCreationDate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_CodeValue2");

      builder.HasOne(d => d.CodeNameSpace)
             .WithMany(p => p.CodeValues)
             .HasForeignKey(d => d.CodeNameSpaceId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_CodeValue1");
    }
  }
}
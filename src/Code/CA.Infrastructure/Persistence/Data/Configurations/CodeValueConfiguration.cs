using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CA.Core.Entities;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class CodeValueConfiguration : IEntityTypeConfiguration<CodeValue>
  {
    public void Configure(EntityTypeBuilder<CodeValue> builder)
    {
      builder.ToTable("mtCodeValue");

      builder.HasKey(e => new { e.RowId, e.ValueId }).HasName("pk_CodeValue");
      builder.HasIndex(e => new { e.RowId, e.Codenamespaceid, e.Orderby, e.ValueId }, "uq_CodeValue").IsUnique();
      builder.Property(e => e.RowId).ValueGeneratedOnAdd().HasColumnName("row_id");
      builder.Property(e => e.ValueId).HasColumnName("value_id");
      builder.Property(e => e.AccountIdCreationdate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeletedate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdatedate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.Codenamespaceid).HasColumnName("codenamespaceid");
      builder.Property(e => e.Creationdate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.Deletedate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.Description).IsRequired().HasMaxLength(100).HasColumnName("description");
      builder.Property(e => e.Isdeleted).HasColumnName("isdeleted");
      builder.Property(e => e.Isroot).HasColumnName("isroot");
      builder.Property(e => e.Issystemrow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.Orderby).HasColumnName("orderby");
      builder.Property(e => e.Parentid).HasColumnName("parentid");
      builder.Property(e => e.Updatedate).HasColumnType("datetime").HasColumnName("updatedate");
      
      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.CodeValues)
             .HasForeignKey(d => d.AccountIdCreationdate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_CodeValue2");

      builder.HasOne(d => d.CodeNameSpaces)
             .WithMany(p => p.CodeValues)
             .HasForeignKey(d => d.Codenamespaceid)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_CodeValue1");
    }
  }
}

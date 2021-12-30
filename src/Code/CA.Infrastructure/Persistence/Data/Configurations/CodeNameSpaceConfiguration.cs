using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CA.Core.Entities;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class CodeNameSpaceConfiguration : IEntityTypeConfiguration<CodeNamespace>
  {
    public void Configure(EntityTypeBuilder<CodeNamespace> builder)
    {
      builder.ToTable("mtCodeNamespace");

      builder.HasKey(e => e.Codenamespaceid).HasName("pk_CodeNamespace");
      builder.HasIndex(e => e.Name, "uq_CodeNamespaceName").IsUnique();
      builder.Property(e => e.Codenamespaceid).HasColumnName("codenamespaceid");
      builder.Property(e => e.AccountIdCreationdate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeletedate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdatedate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.Creationdate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
      builder.Property(e => e.Deletedate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.Isdeleted).HasColumnName("isdeleted");
      builder.Property(e => e.Issystemrow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
      builder.Property(e => e.List).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("list");
      builder.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("name");
      builder.Property(e => e.Updatedate).HasColumnType("datetime").HasColumnName("updatedate");

      builder.HasOne(d => d.AccountIdCreationdateNavigation)
             .WithMany(p => p.CodeNamespaces)
             .HasForeignKey(d => d.AccountIdCreationdate)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("fk_CodeNamespace1");
    }
  }
}

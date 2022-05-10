using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
    public class CodeNameSpaceConfiguration : IEntityTypeConfiguration<CodeNamespace>
    {
        public void Configure(EntityTypeBuilder<CodeNamespace> builder)
        {
            builder.ToTable("mtCodeNamespaces");

            builder.HasKey(e => e.Id).HasName("pk_CodeNamespace");
            builder.HasIndex(e => e.Name, "uq_CodeNamespaceName").IsUnique();

            builder.Property(e => e.Id).HasColumnName("codenamespaceid");
            builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
            builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
            builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
            builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
            builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
            builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
            builder.Property(e => e.List).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("list");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("name");
            builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

            builder.HasOne(d => d.AccountIdCreationdateNavigation)
                   .WithMany(p => p.CodeNamespaces)
                   .HasForeignKey(d => d.AccountIdCreationDate)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_CodeNamespace1");
        }
    }
}

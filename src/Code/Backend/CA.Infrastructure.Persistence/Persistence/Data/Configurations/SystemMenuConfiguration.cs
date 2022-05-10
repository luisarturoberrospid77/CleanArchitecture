using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
    public class SystemMenuConfiguration : IEntityTypeConfiguration<MenuSystem>
    {
        public void Configure(EntityTypeBuilder<MenuSystem> builder)
        {
            builder.ToView("vwMenuSystem");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
            builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
            builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
            builder.Property(e => e.Breadcrumb).HasMaxLength(8000).IsUnicode(false).HasColumnName("breadcrumb");
            builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate");
            builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
            builder.Property(e => e.Description).HasMaxLength(100).HasColumnName("description");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
            builder.Property(e => e.IsSystemRow).HasColumnName("issystemrow");
            builder.Property(e => e.Level).HasColumnName("level");
            builder.Property(e => e.ParentId).HasColumnName("parentid");
            builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");
            builder.Property(e => e.ValueId).HasColumnName("value_id");
        }
    }
}

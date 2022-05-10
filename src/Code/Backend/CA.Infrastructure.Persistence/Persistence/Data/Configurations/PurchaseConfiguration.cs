using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("mtPurchases");

            builder.HasKey(e => e.Id).HasName("pk_PurchaseHeader");
            builder.HasIndex(e => new { e.Id, e.SupplierId }, "uq_PurchaseHeader").IsUnique();

            builder.Property(e => e.Id).HasColumnName("purchase_id");
            builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
            builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
            builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
            builder.Property(e => e.Comments).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("comments");
            builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
            builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
            builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
            builder.Property(e => e.PurchaseGrandTotal).HasColumnType("decimal(15, 2)").HasColumnName("purchase_grand_total");
            builder.Property(e => e.PurchaseSubTotal).HasColumnType("decimal(15, 2)").HasColumnName("purchase_sub_total");
            builder.Property(e => e.PurchaseTax).HasColumnType("decimal(15, 2)").HasColumnName("purchase_tax");
            builder.Property(e => e.Quantity).HasColumnName("quantity");
            builder.Property(e => e.SupplierId).HasColumnName("supplier_id");
            builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

            builder.HasOne(d => d.AccountIdCreationdateNavigation)
                   .WithMany(p => p.Purchases)
                   .HasForeignKey(d => d.AccountIdCreationDate)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_PurchaseHeader1");

            builder.HasOne(d => d.Supplier)
                   .WithMany(p => p.Purchases)
                   .HasForeignKey(d => d.SupplierId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_PurchaseHeader2");
        }
    }
}

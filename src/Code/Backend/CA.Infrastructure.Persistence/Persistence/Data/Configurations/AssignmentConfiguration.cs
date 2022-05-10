using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("mtAssignments");

            builder.HasKey(e => e.Id).HasName("pk_AssignmentHead");
            builder.HasIndex(e => new { e.Id, e.StoreId }, "uq_AssignmentHead").IsUnique();

            builder.Property(e => e.Id).HasColumnName("assignment_id");
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
            builder.Property(e => e.StoreId).HasColumnName("store_id");
            builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

            builder.HasOne(d => d.AccountIdCreationdateNavigation)
                   .WithMany(p => p.Assignments)
                   .HasForeignKey(d => d.AccountIdCreationDate)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_AssignmentHead1");

            builder.HasOne(d => d.Store)
                   .WithMany(p => p.Assignments)
                   .HasForeignKey(d => d.StoreId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_AssignmentHead2");
        }
    }
}

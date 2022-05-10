using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
    public class ItemMovementConfiguration : IEntityTypeConfiguration<ItemMovement>
    {
        public void Configure(EntityTypeBuilder<ItemMovement> builder)
        {
            builder.ToTable("mtItemMovement");

            builder.HasKey(e => new { e.Id, e.Year, e.Month, e.Day }).HasName("pk_ItemMovement");
            builder.HasIndex(e => new { e.Id, e.OriginStoreId, e.PostingStoreId, e.MovementStatus, e.Year, e.Month, e.Day }, "uq_ItemMovement").IsUnique();

            builder.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");
            builder.Property(e => e.Year).HasColumnName("year");
            builder.Property(e => e.Month).HasColumnName("month");
            builder.Property(e => e.Day).HasColumnName("day");
            builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
            builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
            builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
            builder.Property(e => e.Comments).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("comments");
            builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate").HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
            builder.Property(e => e.FinalTotal).HasColumnName("final_total");
            builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
            builder.Property(e => e.IsSystemRow).IsRequired().HasColumnName("issystemrow").HasDefaultValueSql("((1))");
            builder.Property(e => e.MovementStatus).HasColumnName("movement_status");
            builder.Property(e => e.OriginStoreId).HasColumnName("origin_store_id");
            builder.Property(e => e.PostingStoreId).HasColumnName("posting_store_id");
            builder.Property(e => e.SkuId).HasColumnName("sku_id");
            builder.Property(e => e.StartingTotal).HasColumnName("starting_total");
            builder.Property(e => e.SupplierId).HasColumnName("supplier_id");
            builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");

            builder.HasOne(d => d.AccountIdCreationdateNavigation)
                   .WithMany(p => p.ItemMovements)
                   .HasForeignKey(d => d.AccountIdCreationDate)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_ItemMovement1");

            builder.HasOne(d => d.OriginStore)
                   .WithMany(p => p.ItemMovementOriginStores)
                   .HasForeignKey(d => d.OriginStoreId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_ItemMovement3");

            builder.HasOne(d => d.PostingStore)
                   .WithMany(p => p.ItemMovementPostingStores)
                   .HasForeignKey(d => d.PostingStoreId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_ItemMovement5");

            builder.HasOne(d => d.Sku)
                   .WithMany(p => p.ItemMovements)
                   .HasForeignKey(d => d.SkuId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_ItemMovement2");

            builder.HasOne(d => d.Supplier)
                   .WithMany(p => p.ItemMovements)
                   .HasForeignKey(d => d.SupplierId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("fk_ItemMovement4");
        }
    }
}

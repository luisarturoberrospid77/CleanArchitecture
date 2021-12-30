using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.Infrastructure.Persistence.Data.Configurations
{
  public class MovementArticleConfiguration : IEntityTypeConfiguration<MovementArticle>
  {
    public void Configure(EntityTypeBuilder<MovementArticle> builder)
    {
      builder.ToView("vwMovementArticles");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.AccountIdCreationDate).HasColumnName("account_id_creationdate");
      builder.Property(e => e.AccountIdDeleteDate).HasColumnName("account_id_deletedate");
      builder.Property(e => e.AccountIdUpdateDate).HasColumnName("account_id_updatedate");
      builder.Property(e => e.ArticleShortName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("article_short_name");
      builder.Property(e => e.Comments).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("comments");
      builder.Property(e => e.CreationDate).HasColumnType("datetime").HasColumnName("creationdate");
      builder.Property(e => e.Day).HasColumnName("day");
      builder.Property(e => e.DeleteDate).HasColumnType("datetime").HasColumnName("deletedate");
      builder.Property(e => e.Description).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("description");
      builder.Property(e => e.DescriptionMovement).IsRequired().HasMaxLength(100).HasColumnName("description_movement");
      builder.Property(e => e.FinalTotal).HasColumnName("final_total");
      builder.Property(e => e.Id).HasColumnName("Id");
      builder.Property(e => e.IsDeleted).HasColumnName("isdeleted");
      builder.Property(e => e.IsSystemRow).HasColumnName("issystemrow");
      builder.Property(e => e.Month).HasColumnName("month");
      builder.Property(e => e.MovementStatus).HasColumnName("movement_status");
      builder.Property(e => e.OriginStoreId).HasColumnName("origin_store_id");
      builder.Property(e => e.OriginStoreName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("origin_store_name");
      builder.Property(e => e.PostingStoreId).HasColumnName("posting_store_id");
      builder.Property(e => e.PostingStoreName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("posting_store_name");
      builder.Property(e => e.SkuId).HasColumnName("sku_id");
      builder.Property(e => e.StartingTotal).HasColumnName("starting_total");
      builder.Property(e => e.SupplierId).HasColumnName("supplier_id");
      builder.Property(e => e.SupplierName).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("supplier_name");
      builder.Property(e => e.UpdateDate).HasColumnType("datetime").HasColumnName("updatedate");
      builder.Property(e => e.Year).HasColumnName("year");
    }
  }
}
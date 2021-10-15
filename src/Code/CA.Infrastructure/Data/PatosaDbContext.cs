using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using CA.Core.Entities;

namespace CA.Infrastructure.Data
{
    public partial class PatosaDbContext : DbContext
    {
        public PatosaDbContext()
        {
        }

        public PatosaDbContext(DbContextOptions<PatosaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MtArticle> MtArticles { get; set; }
        public virtual DbSet<MtProductType> MtProductTypes { get; set; }
        public virtual DbSet<MtStore> MtStores { get; set; }
        public virtual DbSet<MtUser> MtUsers { get; set; }
        public virtual DbSet<SchemaVersion> SchemaVersions { get; set; }
        public virtual DbSet<VwArticle> VwArticles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<MtArticle>(entity =>
            {
                entity.HasKey(e => e.SkuId)
                    .HasName("pk_Idarticle");

                entity.ToTable("mtArticles");

                entity.HasIndex(e => new { e.SkuId, e.StoreId }, "uq_Idarticle")
                    .IsUnique();

                entity.Property(e => e.SkuId).HasColumnName("sku_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Creationdate)
                    .HasColumnType("datetime")
                    .HasColumnName("creationdate")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ProducttypeId).HasColumnName("producttype_id");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.TotalInShelf).HasColumnName("total_in_shelf");

                entity.Property(e => e.TotalInVault).HasColumnName("total_in_vault");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.MtArticles)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Idarticle1");

                entity.HasOne(d => d.Producttype)
                    .WithMany(p => p.MtArticles)
                    .HasForeignKey(d => d.ProducttypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Idarticle3");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.MtArticles)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Idarticle2");
            });

            modelBuilder.Entity<MtProductType>(entity =>
            {
                entity.HasKey(e => e.ProducttypeId)
                    .HasName("pk_IdProductType");

                entity.ToTable("mtProductTypes");

                entity.HasIndex(e => new { e.ProducttypeId, e.AccountId }, "uq_IdProductType")
                    .IsUnique();

                entity.Property(e => e.ProducttypeId).HasColumnName("producttype_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Creationdate)
                    .HasColumnType("datetime")
                    .HasColumnName("creationdate")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.MtProductTypes)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IdProductType");
            });

            modelBuilder.Entity<MtStore>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("pk_IdStore");

                entity.ToTable("mtStores");

                entity.HasIndex(e => new { e.StoreId, e.AccountId }, "uq_IdStore")
                    .IsUnique();

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Creationdate)
                    .HasColumnType("datetime")
                    .HasColumnName("creationdate")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.MtStores)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IdStore");
            });

            modelBuilder.Entity<MtUser>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("pk_IdUser");

                entity.ToTable("mtUsers");

                entity.HasIndex(e => e.AccountId, "uq_IdUser")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Creationdate)
                    .HasColumnType("datetime")
                    .HasColumnName("creationdate")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Passwordhash)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("passwordhash");

                entity.Property(e => e.Updatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedate");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<SchemaVersion>(entity =>
            {
                entity.Property(e => e.Applied).HasColumnType("datetime");

                entity.Property(e => e.ScriptName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<VwArticle>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_articles");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ProductTypeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("product_type_name");

                entity.Property(e => e.SkuId).HasColumnName("sku_id");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("store_name");

                entity.Property(e => e.TotalInShelf).HasColumnName("total_in_shelf");

                entity.Property(e => e.TotalInVault).HasColumnName("total_in_vault");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

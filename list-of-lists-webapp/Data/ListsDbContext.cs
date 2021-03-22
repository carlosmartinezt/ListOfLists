using list_of_lists_webapp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace list_of_lists_webapp.Data {
    public partial class ListsDbContext : IdentityDbContext<IdentityUser> {
        public ListsDbContext() {
        }

        public ListsDbContext(DbContextOptions<ListsDbContext> options)
            : base(options) {
        }

        public virtual DbSet<DataType> DataTypes { get; set; }
        public virtual DbSet<Editor> Editors { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<FieldValue> FieldValues { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<List> Lists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Lists");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<DataType>(entity => {
                entity.ToTable("DataType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SystemType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Editor>(entity => {
                entity.ToTable("Editor");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Field>(entity => {
                entity.ToTable("Field");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<FieldValue>(entity => {
                entity.ToTable("FieldValue");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity => {
                entity.ToTable("Item");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<List>(entity => {
                entity.ToTable("List");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasDefaultValueSql("(newid())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

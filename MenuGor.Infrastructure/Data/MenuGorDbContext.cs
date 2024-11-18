// File: MenuGor.Infrastructure/Data/MenuGorDbContext.cs

using Microsoft.EntityFrameworkCore;
using MenuGor.Core.Entities;

namespace MenuGor.Infrastructure.Data
{
    public class MenuGorDbContext : DbContext
    {
        public MenuGorDbContext(DbContextOptions<MenuGorDbContext> options) : base(options)
        {
        }

        // Entity setlerinin tanımlanması
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tüm entityler için temel yapılandırmalar
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Tablo isimlerini entity ismiyle aynı yap
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);

                // String tipindeki tüm alanlar için maksimum uzunluk belirleme
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string) &&
                        property.Name != "ConnectionString") // Bağlantı stringi hariç
                    {
                        property.SetMaxLength(500);
                    }
                }
            }

            // Admin yapılandırması
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admins");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.DeletedBy).IsRequired(false);
                entity.Property(e => e.DeletedDate).IsRequired(false);;
                entity.Property(e => e.UpdatedBy).IsRequired(false);
                entity.Property(e => e.UpdatedDate).IsRequired(false);
                // Username ve Email için unique index
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            // Bayi - Firma ilişkisi
            modelBuilder.Entity<Company>()
                .HasOne(c => c.Dealer)
                .WithMany(d => d.Companies)
                .HasForeignKey(c => c.DealerId)
                .IsRequired() // Firma mutlaka bir bayiye bağlı olmalı
                .OnDelete(DeleteBehavior.Restrict); // Bayi silindiğinde firmalar silinmesin

            // Firma - Şube ilişkisi
            modelBuilder.Entity<Branch>()
                .HasOne(b => b.Company)
                .WithMany(c => c.Branches)
                .HasForeignKey(b => b.CompanyId)
                .IsRequired() // Şube mutlaka bir firmaya bağlı olmalı
                .OnDelete(DeleteBehavior.Restrict); // Firma silindiğinde şubeler silinmesin

            // Kategori yapılandırması
            modelBuilder.Entity<Category>(entity =>
            {
                // Temel alan yapılandırmaları
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Description)
                    .HasMaxLength(500);

                // Firma ile ilişki
                entity.HasOne(c => c.Company)
                    .WithMany(c => c.Categories)
                    .HasForeignKey(c => c.CompanyId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                // Şube ile ilişki (opsiyonel)
                entity.HasOne(c => c.Branch)
                    .WithMany(b => b.Categories)
                    .HasForeignKey(c => c.BranchId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Ürün yapılandırması
            modelBuilder.Entity<Product>(entity =>
            {
                // Temel alan yapılandırmaları
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(p => p.Description)
                    .HasMaxLength(1000);

                entity.Property(p => p.Price)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(p => p.ImageUrl)
                    .HasMaxLength(500);

                // Kategori ile ilişki
                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                // Firma ile ilişki
                entity.HasOne(p => p.Company)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CompanyId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                // Şube ile ilişki (opsiyonel)
                entity.HasOne(p => p.Branch)
                    .WithMany(b => b.Products)
                    .HasForeignKey(p => p.BranchId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
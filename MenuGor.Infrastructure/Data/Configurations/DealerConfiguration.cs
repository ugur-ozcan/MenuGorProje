// File: MenuGor.Infrastructure/Data/Configurations/DealerConfiguration.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MenuGor.Core.Entities;

namespace MenuGor.Infrastructure.Data.Configurations
{
    /// <summary>
    /// Dealer entity'si için veritabanı konfigürasyonu
    /// </summary>
    public class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.ToTable("Dealers");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(d => d.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(d => d.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.PasswordHash)
                .IsRequired();

            builder.Property(d => d.Address)
                .HasMaxLength(500);

            builder.Property(d => d.ApiKey)
                .HasMaxLength(100);

            // İlişkiler
            builder.HasMany(d => d.Companies)
                .WithOne(c => c.Dealer)
                .HasForeignKey(c => c.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
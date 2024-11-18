// File: MenuGor.Infrastructure/Data/Configurations/BlockedIpConfiguration.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MenuGor.Core.Entities;

namespace MenuGor.Infrastructure.Data.Configurations
{
    public class BlockedIpConfiguration : IEntityTypeConfiguration<BlockedIp>
    {
        public void Configure(EntityTypeBuilder<BlockedIp> builder)
        {
            // Tablo adı
            builder.ToTable("BlockedIps");

            // Primary key
            builder.HasKey(b => b.Id);

            // IP adresi alanı
            builder.Property(b => b.BlockedAddress)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Engellenen IP adresi");

            // Engelleme bitiş tarihi
            builder.Property(b => b.BlockedUntil)
                .IsRequired()
                .HasComment("IP engelinin kalkacağı tarih");

            // Engelleme nedeni
            builder.Property(b => b.BlockReason)
                .IsRequired()
                .HasMaxLength(500)
                .HasComment("IP'nin engellenme nedeni");
        }
    }
}
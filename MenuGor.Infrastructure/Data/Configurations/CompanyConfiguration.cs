// File: MenuGor.Infrastructure/Data/Configurations/CompanyConfiguration.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MenuGor.Core.Entities;

namespace MenuGor.Infrastructure.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Slug).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(256);
            builder.Property(c => c.PhoneNumber).HasMaxLength(20);
            builder.Property(c => c.Address).HasMaxLength(500);
            builder.Property(c => c.InstagramLink).HasMaxLength(255);

            // Soft delete için
            builder.HasQueryFilter(c => !c.IsDeleted);

            // Dealer ile ilişki
            builder.HasOne(c => c.Dealer)
                .WithMany(d => d.Companies)
                .HasForeignKey(c => c.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
// File: MenuGor.Infrastructure/Data/Configurations/BranchConfiguration.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MenuGor.Core.Entities;

namespace MenuGor.Infrastructure.Data.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branches");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Slug).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Location).HasMaxLength(500);

            // Soft delete için
            builder.HasQueryFilter(b => !b.IsDeleted);

            // Company ile ilişki
            builder.HasOne(b => b.Company)
                .WithMany(c => c.Branches)
                .HasForeignKey(b => b.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
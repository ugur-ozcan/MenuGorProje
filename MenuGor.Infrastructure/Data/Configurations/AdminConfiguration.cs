using MenuGor.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGor.Infrastructure.Data.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            // Audit fields
            builder.Property(x => x.CreatedBy)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.UpdatedBy)
                .HasMaxLength(500);
 

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.DeletedBy)
           .HasMaxLength(500)
           .IsRequired(false);  // Null değerlere izin ver

            builder.Property(x => x.DeletedDate)
                .IsRequired(false);  // Null değerlere izin ver

            builder.Property(x => x.IsDeleted)
           .IsRequired()
           .HasDefaultValue(false);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS_System___WPF.Models;

namespace POS_System___WPF.Data.EntityConfigrations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Key
            builder.HasKey(r => r.Id);

            // Name
            builder.HasIndex(r => r.Name)
                .IsUnique();
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Description
            builder.Property(r => r.Description).HasMaxLength(500);

            // Relationship (RolePermissions → Roles) Many to Many
            builder.HasMany(r => r.RolePermissions)
                .WithMany(rp => rp.Roles);

        }
    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS_System___WPF.Models;
using System.Reflection.Emit;

namespace POS_System___WPF.Data.EntityConfigrations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            // Key
            builder.HasKey(rp => rp.Id);
        }
    }
}

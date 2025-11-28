using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS_System___WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Data.EntityConfigrations
{
    public class InventoryLogConfiguration : IEntityTypeConfiguration<InventoryLog>
    {
        public void Configure(EntityTypeBuilder<InventoryLog> builder)
        {
            // Key
            builder.HasKey(l => l.LogID);

            // Quantity Added or removed
            builder.Property(l => l.StockChanged)
                .HasColumnType("decimal(18,2)");

            // LogDate (Date)
            builder.Property(l => l.LogDate)
                .HasDefaultValueSql("GETUTCDATE()");

            // Convert Enum item to string
            builder.Property(l => l.ChangeType)
                            .HasConversion<string>();
        }
    }
}

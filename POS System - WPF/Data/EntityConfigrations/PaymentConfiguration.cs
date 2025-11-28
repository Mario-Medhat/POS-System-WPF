
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS_System___WPF.Models;
using System.Reflection.Emit;

namespace POS_System___WPF.Data.EntityConfigrations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // Key
            builder.HasKey(p => p.PaymentId);

            // Amount
            builder.Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            // PaidAt (DateTime)
            builder.Property(p => p.PaidAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Convert Enum item to string
            builder.Property(p => p.PaymentMethod)
            .HasConversion<string>(); 
        }
    }
}

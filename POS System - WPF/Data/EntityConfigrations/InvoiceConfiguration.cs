using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS_System___WPF.Models;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        // Key
        builder.HasKey(i => i.InvoiceId);

        // Relationship (InvoiceItems → Invoice) Many to One
        builder.HasMany(i => i.InvoiceItems)
            .WithOne(ii => ii.Invoice)
            .HasForeignKey(ii => ii.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relationship (Payments → Invoice) Many to One
        builder.HasMany(i => i.Payments)
            .WithOne(p => p.Invoice)
            .HasForeignKey(p => p.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        // Set InvoiceDate default Value
        builder.Property(p => p.InvoiceDate)
            .HasColumnType("decimal(18,2)");

        // Convert Enum item to string
        builder.Property(i => i.PaymentStatus)
            .HasConversion<string>();

        builder.Property(i => i.InvoiceStatus)
            .HasConversion<string>();
    }
}

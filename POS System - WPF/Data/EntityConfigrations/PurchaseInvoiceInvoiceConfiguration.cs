using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS_System___WPF.Models;

public class PurchaseInvoiceInvoiceConfiguration : IEntityTypeConfiguration<PurchaseInvoice>
{
    public void Configure(EntityTypeBuilder<PurchaseInvoice> builder)
    {
        // Relationship (PurchaseInvoices → Supplier) Many to One
        builder.HasOne(x => x.Supplier)
            .WithMany(i => i.PurchaseInvoices)
            .HasForeignKey(x => x.SupplierId);
    }
}


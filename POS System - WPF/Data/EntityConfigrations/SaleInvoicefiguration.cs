using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS_System___WPF.Models;

public class SaleInvoicefiguration : IEntityTypeConfiguration<SaleInvoice>
{
    public void Configure(EntityTypeBuilder<SaleInvoice> builder)
    {
        // Relationship (SaleInvoices → Customer) Many to One
        builder.HasOne(x => x.Customer)
            .WithMany(i => i.SaleInvoices)
            .HasForeignKey(x => x.CustomerId);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS_System___WPF.Models;

public class PriceLevelConfiguration : IEntityTypeConfiguration<PriceLevel>
{
    public void Configure(EntityTypeBuilder<PriceLevel> b)
    {
        // Key 
        b.HasKey(x => x.Id);

        // Level Name
        b.Property(x => x.LevelName)
            .IsRequired()
            .HasMaxLength(100);

        // Price
        b.Property(x => x.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        // CreatedAt (Date)
        b.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        // Relationship (PriceLevels → Product) Many to One
        b.HasOne(x => x.Product)
        .WithMany(p => p.PriceLevels)
        .HasForeignKey(x => x.ProductId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}

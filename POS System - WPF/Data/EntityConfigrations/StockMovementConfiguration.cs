using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS_System___WPF.Models;

public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> b)
    {
        b.ToTable("StockMovements");

        b.HasKey(x => x.Id);

        b.Property(x => x.Quantity)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        b.Property(x => x.MovementType)
            .IsRequired()
            .HasMaxLength(50);

        b.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        // Product relation
        b.HasOne(x => x.Product)
            .WithMany(p => p.StockMovements)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        // User relation
        b.HasOne(x => x.CreatedByUser)
            .WithMany(u => u.StockMovements)
            .HasForeignKey(x => x.CreatedByUserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

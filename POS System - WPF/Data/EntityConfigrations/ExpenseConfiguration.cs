using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS_System___WPF.Models;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        // Key
        builder.HasKey(x => x.Id);

        // Amount
        builder.Property(x => x.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        // Description
        builder.Property(x => x.Description)
            .HasMaxLength(500);

        // Category
        builder.Property(x => x.Category)
            .HasMaxLength(100);

        // Date
        builder.Property(x => x.Date)
            .HasDefaultValueSql("GETUTCDATE()");

        // Relationship (Expense → User) Many to One
        builder.HasOne(x => x.CreatedByUser)
            .WithMany(u => u.Expenses)
            .HasForeignKey(x => x.CreatedByUserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

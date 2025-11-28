using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS_System___WPF.Models;

public class NotificationsLogConfiguration : IEntityTypeConfiguration<NotificationsLog>
{
    public void Configure(EntityTypeBuilder<NotificationsLog> b)
    {
        // Key
        b.HasKey(x => x.Id);

        // Title
        b.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        // Message
        b.Property(x => x.Message)
            .IsRequired()
            .HasMaxLength(1000);

        // Type
        b.Property(x => x.Type)
            .IsRequired()
            .HasMaxLength(50);

        // IsRead
        b.Property(x => x.IsRead)
            .HasDefaultValue(false);

        // CreatedAt (Date)
        b.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        // Relationship (Notifications → LoggedOnUser) Many to One
        b.HasOne(x => x.LoggedOnUser)
            .WithMany(u => u.Notifications)
            .HasForeignKey(x => x.LoggedOnUserId)
            .OnDelete(DeleteBehavior.SetNull);

        // Convert Enum item to string
        b.Property(x => x.Type)
            .HasConversion<string>();

    }
}

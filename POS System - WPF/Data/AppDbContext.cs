using Microsoft.EntityFrameworkCore;
using POS_System___WPF.Models;

namespace POS_System___WPF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // ==========================
        // DbSets
        // ==========================

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<InventoryLog> InventoryLogs { get; set; }

        // ==========================
        // Configuration
        // ==========================

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // USER
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // CUSTOMER
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Invoices)
                .WithOne(i => i.Customer)
                .HasForeignKey(i => i.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // SUPPLIER
            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.SetNull);

            // CATEGORY
            modelBuilder.Entity<ProductCategory>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            // PRODUCT
            modelBuilder.Entity<Product>()
                .HasMany(p => p.InvoiceItems)
                .WithOne(ii => ii.Product)
                .HasForeignKey(ii => ii.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.InventoryLogs)
                .WithOne(l => l.Product)
                .HasForeignKey(l => l.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // INVOICE
            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.InvoiceItems)
                .WithOne(ii => ii.Invoice)
                .HasForeignKey(ii => ii.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.Payments)
                .WithOne(p => p.Invoice)
                .HasForeignKey(p => p.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // INVOICE ITEM
            modelBuilder.Entity<InvoiceItem>()
                .HasKey(ii => ii.InvoiceId);

            // PAYMENT
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            // INVENTORY LOG
            modelBuilder.Entity<InventoryLog>()
                .Property(l => l.StockChanged)
                .HasColumnType("decimal(18,2)");
        }
    }
}

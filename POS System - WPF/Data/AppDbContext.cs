using Microsoft.EntityFrameworkCore;
using POS_System___WPF.Data.EntityConfigrations;
using POS_System___WPF.Models;

namespace POS_System___WPF.Data
{
    public class AppDbContext : DbContext
    {
        // ==========================
        // DbSets
        // ==========================

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<SaleInvoice> SaleInvoices { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<InventoryLog> InventoryLogs { get; set; }

        // ==========================
        // Configuration
        // ==========================

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new SaleInvoicefiguration());
            modelBuilder.ApplyConfiguration(new PurchaseInvoiceInvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceItemConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryLogConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationsLogConfiguration());
            modelBuilder.ApplyConfiguration(new PriceLevelConfiguration());
            modelBuilder.ApplyConfiguration(new StockMovementConfiguration());

        }
    }
}

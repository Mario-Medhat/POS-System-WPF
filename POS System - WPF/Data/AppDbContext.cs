using Microsoft.EntityFrameworkCore;
using POS_System___WPF.Models;

namespace POS_System___WPF.Data
{
    /// <summary>
    /// Application database context.
    /// Handles database models, configuration, and entity relationships.
    /// </summary>
    public class AppDbContext : DbContext
    {
        // DbSets represent database tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SaleItem> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<InventoryLog> InventoryLogs { get; set; }
        public DbSet<Payment> Payments { get; set; }

        /// <summary>
        /// Default constructor used when dependency injection is not configured.
        /// </summary>
        public AppDbContext() { }

        /// <summary>
        /// Constructor used when dependency injection provides DbContextOptions.
        /// </summary>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Configures the database provider.
        /// This runs ONLY when no external configuration (DI) is provided.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Local SQL Server configuration
                optionsBuilder.UseSqlServer(
                    @"Data Source=it-esaleh\sqlexpress;
                      Initial Catalog=POSDB;
                      Integrated Security=True;
                      Encrypt=True;
                      Trust Server Certificate=True");
            }
        }

        /// <summary>
        /// Configures entity rules, precision settings, and relationships.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureInventoryLog(modelBuilder);
            ConfigureProducts(modelBuilder);
            ConfigureSaleItems(modelBuilder);
            ConfigurePayments(modelBuilder);
            ConfigureRelationships(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        // ------------------------------
        // Entity Configurations
        // ------------------------------

        private static void ConfigureInventoryLog(ModelBuilder modelBuilder)
        {
            // Primary key
            modelBuilder.Entity<InventoryLog>()
                .HasKey(l => l.LogID);
        }

        private static void ConfigureProducts(ModelBuilder modelBuilder)
        {
            // Product.Price → decimal precision
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }

        private static void ConfigureSaleItems(ModelBuilder modelBuilder)
        {
            // **IMPORTANT**
            // TotalAmount is a calculated property → Not Mapped / ignored.
            modelBuilder.Entity<SaleItem>()
                .Property(s => s.TotalAmount)
                .HasColumnType("decimal(18,2)")
                .HasComputedColumnSql("[Quantity] * [PriceAtSaleTime]");

        }

        private static void ConfigurePayments(ModelBuilder modelBuilder)
        {
            // Payment.Amount → decimal precision
            modelBuilder.Entity<SaleItem>()
            .Ignore(s => s.TotalAmount);

        }

        // ------------------------------
        // Relationships
        // ------------------------------

        private static void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // SaleItem → Customer (Many-to-One)
            modelBuilder.Entity<SaleItem>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerID);

            // SaleItem → Product (Many-to-One)
            modelBuilder.Entity<SaleItem>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductID);

            // Payment → SaleItem (Many-to-One)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.SaleItem)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.SaleID);

            // InventoryLog → Product (Many-to-One)
            modelBuilder.Entity<InventoryLog>()
                .HasOne(l => l.Product)
                .WithMany(p => p.InventoryLogs)
                .HasForeignKey(l => l.ProductID);
        }
    }
}

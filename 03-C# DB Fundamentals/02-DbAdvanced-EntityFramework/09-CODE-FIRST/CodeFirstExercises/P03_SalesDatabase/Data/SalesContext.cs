using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(
                product =>
                {
                    product.HasKey(p => p.ProductId);
                    product.Property(p => p.Name).HasMaxLength(50).IsUnicode(true);
                    product.Property(p => p.Description).HasMaxLength(250).HasDefaultValue("No description");
                }
            );

            modelBuilder.Entity<Customer>(
                customer =>
                {
                    customer.HasKey(c => c.CustomerId);
                    customer.Property(c => c.Name).HasMaxLength(100).IsUnicode(true);
                    customer.Property(c => c.Email).HasMaxLength(80).IsUnicode(false);
                }
            );

            modelBuilder.Entity<Store>(
                store =>
                {
                    store.HasKey(s => s.StoreId);
                    store.Property(s => s.Name).HasMaxLength(80).IsUnicode(true);                    
                }
            );

            modelBuilder.Entity<Sale>(
                sale =>
                {
                    sale.HasKey(s => s.SaleId);
                    sale.Property(p => p.Date).HasDefaultValueSql("GETDATE()");
                    sale.HasOne(s => s.Product).WithMany(p => p.Sales).HasForeignKey(s => s.ProductId);
                    sale.HasOne(s => s.Customer).WithMany(c => c.Sales).HasForeignKey(s => s.CustomerId);
                    sale.HasOne(s => s.Store).WithMany(s => s.Sales).HasForeignKey(s => s.StoreId);
                }
            );
        }
    }
}

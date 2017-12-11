namespace ProductsShopSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using ProductsShopSystem.Data.Models;

    class ProductsShopContext : DbContext
    {
        public ProductsShopContext() { }

        public ProductsShopContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryProduct> CategoriesProducts { get; set; }

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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(60)
                    .IsRequired(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(60)
                    .IsRequired(true);

                entity.Property(e => e.Age)
                    .IsRequired(false);

                entity.HasMany<Product>(u => u.BoughtProducts)
                    .WithOne(p => p.Buyer)
                    .HasForeignKey(p => p.BuyerId);

                entity.HasMany<Product>(u => u.SoldProducts)
                    .WithOne(p => p.Seller)
                    .HasForeignKey(p => p.SellerId);
            });

            modelBuilder.Entity<CategoryProduct>(e =>
            {
                e.HasKey(cp => new { cp.CategotyId, cp.ProductId });
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(c => c.Id);

                e.Property(c => c.Name)
                    .HasMaxLength(15)                    
                    .IsRequired(true);

                e.HasMany<CategoryProduct>(c => c.Products)
                    .WithOne(cp => cp.Category)
                    .HasForeignKey(cp => cp.CategotyId);                                
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(p => p.Id);

                e.Property(p => p.Name)
                    .HasMaxLength(250)
                    .IsRequired(true);

                e.Property(p => p.BuyerId)
                    .IsRequired(false);
                
                e.HasMany<CategoryProduct>(p => p.Categories)
                    .WithOne(cp => cp.Product)
                    .HasForeignKey(cp => cp.ProductId);
            });
        }
    }
}

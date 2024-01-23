using ProductServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductServiceAPI.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 3,
                    Name = "Express Delivery",
                    Price = 20.0,
                    Description = "Fast and reliable product delivery service.",
                    isAvailable = true,
                    UserId = 125
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Gift Wrapping",
                    Price = 2.99,
                    Description = "Elegant and festive gift wrapping for all occasions.",
                    isAvailable = true,
                    UserId = 126
                },
                new Product
                {
                    ProductId = 1,
                    Name = "Product A",
                    Price = 100.0,
                    Description = "Description of Product A",
                    isAvailable = true,
                    UserId = 123
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Product B",
                    Price = 150.0,
                    Description = "Description of Product B",
                    isAvailable = false,
                    UserId = 124
                }
            );
        }
    }
}

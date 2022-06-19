using Microsoft.EntityFrameworkCore;

namespace ProductInventory.Api
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        public DatabaseContext(
            DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var products = new List<Product>();
            for (int i = 1; i < 10; i++)
                products.Add(new Product()
                {
                    Id = i,
                    Name = $"Product {i}",
                    Description = $"Description {i}",
                    Price = i * 2,
                    Quantity = i * 5 % 25
                });

            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}

using Autoshop.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Autoshop.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product()
                {
                    ProductId = 1,
                    Name = "Samosa",
                    Price = 15,
                    Description = "Praesent scelerisque, mi sed",
                    ImageUrl = "",
                    CategoryName = "Appetizer"
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product()
                {
                    ProductId = 2,
                    Name = "Samosa",
                    Price = 13.99,
                    Description = "Praesent scelerisque, mi sed",
                    ImageUrl = "",
                    CategoryName = "Appetizer"
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product()
                {
                    ProductId = 3,
                    Name = "Samosa",
                    Price = 22,
                    Description = "Praesent scelerisque, mi sed",
                    ImageUrl = "",
                    CategoryName = "Dessert"
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product()
                {
                    ProductId = 4,
                    Name = "Samosa",
                    Price = 15,
                    Description = "Praesent scelerisque, mi sed",
                    ImageUrl = "",
                    CategoryName = "Entree"
                }
            );
        }
    }
}

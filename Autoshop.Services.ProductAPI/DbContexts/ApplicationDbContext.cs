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

            modelBuilder.Entity<Product>().HasData(new Product
                {
                    ProductId = 1,
                    Name = "Leopard 2",
                    Price = 150000.0,
                    Description = string.Empty,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Leopard_2_A5_der_Bundeswehr.jpg/300px-Leopard_2_A5_der_Bundeswehr.jpg",
                    CategoryName = "Main battle tanks"
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product
                {
                    ProductId = 2,
                    Name = "Type 99A",
                    Price = 200000.0,
                    Description = string.Empty,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/27/ZTZ-99A_MBT_20170716.jpg/300px-ZTZ-99A_MBT_20170716.jpg",
                    CategoryName = "Main battle tanks"
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product
                {
                    ProductId = 3,
                    Name = "Challenger 2",
                    Price = 100000.0,
                    Description = string.Empty,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Challenger_2_Main_Battle_Tank_patrolling_outside_Basra%2C_Iraq_MOD_45148325.jpg/300px-Challenger_2_Main_Battle_Tank_patrolling_outside_Basra%2C_Iraq_MOD_45148325.jpg",
                    CategoryName = "Main battle tanks"
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product
                {
                    ProductId = 4,
                    Name = "M1A1/M1A2",
                    Price = 175000.0,
                    Description = string.Empty,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/92/Mounted_Soldier_System_%28MSS%29.jpg/300px-Mounted_Soldier_System_%28MSS%29.jpg",
                    CategoryName = "Main battle tanks"
                }
            );
        }
    }
}

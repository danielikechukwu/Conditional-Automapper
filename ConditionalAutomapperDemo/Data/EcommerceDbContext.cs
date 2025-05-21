using ConditionalAutomapperDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ConditionalAutomapperDemo.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // SEEDING DUMMY DATA

            // 1) Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "John Doe", IsActive = true  },
                new Customer { Id = 2, Name = "Alice Wonderland", IsActive = false }
                );

            // 2) Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Gaming Laptop", Price = 1500m, IsAvailable = true },
                new Product { Id = 2, Name = "Headphones", Price = 200m, IsAvailable = true },
                new Product { Id = 3, Name = "Old Monitor", Price = 300m, IsAvailable = false }
                );

            // 3) Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, CustomerId = 1, OrderDate = new DateTime(2024, 01, 10), IsShipped = true, ShippingCost = 25m, OrderTotal = 0m },
                new Order { Id = 2, CustomerId = 1, OrderDate = new DateTime(2024, 01, 15), IsShipped = false, ShippingCost = 0m, OrderTotal = 0m },
                new Order { Id = 3, CustomerId = 2, OrderDate = new DateTime(2024, 02, 01), IsShipped = true, ShippingCost = 15m, OrderTotal = 0m }
                );

            // 4) OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 1500m, Discount = 0m },
                new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 2, UnitPrice = 200m, Discount = 0m },
                new OrderItem { Id = 3, OrderId = 2, ProductId = 1, Quantity = 1, UnitPrice = 1500m, Discount = 100m },
                new OrderItem { Id = 4, OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 300m, Discount = 50m }
                );

        }


        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }    

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

    }
}

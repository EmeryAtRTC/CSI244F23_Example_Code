using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Data
{
    public class StoreContext : DbContext
    {
        //Contructur
        //This constructor is going to be used by the services collection
        //We are taking in an options object and passing it to the base constructor
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {

        }
        //The next thing we need is DbSet for each table in the database
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        //next step setup your databsae connection
        //There is a method called OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //I can seed my database in here - Old way. I would no longer do this
            modelBuilder.Entity<Product>().HasData(
                    new Product() { Id = 1, Name = "4090", Price = 1600m, BarCode = "234098" },
                    new Product() { Id = 2, Name = "IPhone", Price = 1000m, BarCode = "2938747" });
            base.OnModelCreating(modelBuilder);
        }


    }
}

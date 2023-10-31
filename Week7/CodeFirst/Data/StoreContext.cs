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
    }
}

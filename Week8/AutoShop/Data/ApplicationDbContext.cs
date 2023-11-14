using AutoShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoShop.Data
{
    //IdentityDBContext
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //I was missing my DBset(s) inside of my dbcontext
        //This is all of your tables
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ServicePerformed> ServicesPerformed { get; set; }
        public DbSet<TechnicianStatus> TechnicianStatuses { get; set; }
    }
}
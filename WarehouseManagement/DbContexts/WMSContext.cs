using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Hosting;
using System.Data;
using WarehouseManagement.Entits;

namespace WarehouseManagement.Contexts
{
    public class WMSContext:DbContext
    {
        public DbSet<Containerr> Containers { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Package> Packages { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<WarehouseLocation> WarehouseLocations { get; set; } = null!;
        public WMSContext(DbContextOptions<WMSContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}

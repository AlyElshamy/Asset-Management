using AssetProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetProject.Data
{
    public class AssetContext :DbContext
    {
        public AssetContext(DbContextOptions<AssetContext> options) :base(options)
        {
        }

        public DbSet<Department> Departments { set; get; }
        public DbSet<Country> Countries { set; get; }
        public DbSet<Location> Locations { set; get; }
        public DbSet<Tenant> Tenants { set; get; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

    }
}

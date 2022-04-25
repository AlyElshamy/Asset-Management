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
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PurchaseAsset> PurchaseAssets { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<DepreciationMethod> DepreciationMethods { get; set; }
        public DbSet<Asset> Assets { get; set; }

    }
}

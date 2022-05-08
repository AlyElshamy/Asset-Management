using AssetProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetProject.Data
{
    public class AssetContext : DbContext
    {
        public AssetContext(DbContextOptions<AssetContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //DepreciationMethod
            modelBuilder.Entity<DepreciationMethod>().HasData(new DepreciationMethod {DepreciationMethodId = 1,DepreciationMethodTitle= "Straight Line"});
            modelBuilder.Entity<DepreciationMethod>().HasData(new DepreciationMethod { DepreciationMethodId = 2, DepreciationMethodTitle = "Declining Balance" });
            modelBuilder.Entity<DepreciationMethod>().HasData(new DepreciationMethod { DepreciationMethodId = 3, DepreciationMethodTitle = "Double Declining Balance" });
            modelBuilder.Entity<DepreciationMethod>().HasData(new DepreciationMethod { DepreciationMethodId = 4, DepreciationMethodTitle = "150% Declining Balance" });
            modelBuilder.Entity<DepreciationMethod>().HasData(new DepreciationMethod { DepreciationMethodId = 5, DepreciationMethodTitle = "Sum of the Years' Digits" });

            //ActionType
            modelBuilder.Entity<ActionType>().HasData(new ActionType { ActionTypeId = 1, ActionTypeTitle = "To Employee" });
            modelBuilder.Entity<ActionType>().HasData(new ActionType { ActionTypeId = 2, ActionTypeTitle = "To Department" });



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
        public DbSet<AssetPhotos> AssetPhotos { get; set; }
        public DbSet<AssetMovement> AssetMovements { get; set; }
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<AssetsInsurance> AssetsInsurances { get; set; }
        public DbSet<AssetContract> AssetContracts { get; set; }
        public DbSet<AssetDocument> assetDocuments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AssetLeasing> AssetLeasings { get; set; }
        public DbSet<SellAsset> sellAssets { get; set; }
        public DbSet<AssetBroken> assetBrokens { get; set; }

        public DbSet<AssetRepair> AssetRepairs { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<AssetLost> AssetLosts { get; set; }
        public DbSet<DisposeAsset> DisposeAssets { get; set; }

        public DbSet<AssetMaintainance> AssetMaintainances { get; set; }
        public DbSet<AssetMaintainanceFrequency> AssetMaintainanceFrequencies { get; set; }
        public DbSet<MaintainanceStatus> MaintainanceStatuses { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<AssetMovementDirection> AssetMovementDirections { get; set; }
        public DbSet<AssetStatus> AssetStatuses { get; set; }
        public DbSet<AssetLog> AssetLogs { get; set; }
        public DbSet<ActionLog> ActionLogs { get; set; }

    }
}

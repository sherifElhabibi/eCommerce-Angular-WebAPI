using Core.Entities;
using eCommerce.Entities;
using Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions options):base(options){}
        public DbSet<Product> Products { get; set; } 
        public DbSet<ProductBrand> ProductsBrands { get; set; } 
        public DbSet<ProductType> ProductsTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}

using Core.Entities;
using eCommerce.Entities;
using Infrastructure.Data;
using System.Text.Json;

namespace eCommerce.Data.DbInitializer
{
    public class StoreContextInitializer
    {
        public static async Task SeedAsync(StoreContext context)
        {
           if(!context.ProductsBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductsBrands.AddRange(brands);
            }
            if (!context.ProductsTypes.Any())
            {
                var typeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductBrand>>(typeData);
                context.ProductsBrands.AddRange(types);
            }
            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<ProductBrand>>(productsData);
                context.ProductsBrands.AddRange(products);
            }
            if(context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }

        }
    }
}





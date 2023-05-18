using Core.Entities;
using Core.Interfaces;
using eCommerce.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType).ToListAsync();
            return products;

        }

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p=>p.ProductType)
                .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<IEnumerable<ProductBrand>> GetProductBrandsAsync()
        {
            var brands = await _context.ProductsBrands.ToListAsync();
            return brands;
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            var types = await _context.ProductsTypes.ToListAsync();
            return types;

        }
    }
}

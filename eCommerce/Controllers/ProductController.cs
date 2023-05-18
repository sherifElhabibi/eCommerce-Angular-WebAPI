using Core.Entities;
using Core.Interfaces;
using eCommerce.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _context;
        private readonly IGenericRepository<ProductBrand> _brandContext;
        private readonly IGenericRepository<ProductType> _typeContext;
        private readonly IGenericRepository<Product> _productContext;
        public ProductController(
            IProductRepository context, 
            IGenericRepository<ProductBrand> brandContext,                                                  
            IGenericRepository<ProductType> typeContext,
            IGenericRepository<Product> productContext)
        { 
            _context = context;
            _brandContext = brandContext;
            _typeContext = typeContext;
            _productContext = productContext;
        }

        public ProductController(IProductRepository storeContext)
        {
            _context = storeContext;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var products = await _productContext.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productContext.GetByIdAsync(id);
            
        }
        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            var brands = await _brandContext.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<ProductBrand>> GetProductTypes()
        {
            var types = await _typeContext.GetAllAsync();
            return Ok(types);
        }
    }
}

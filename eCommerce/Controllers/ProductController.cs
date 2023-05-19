using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using eCommerce.DTOs;
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
    public class ProductController : BaseApiController
    {
        //private readonly IProductRepository _context;
        private readonly IGenericRepository<ProductBrand> _brandContext;
        private readonly IGenericRepository<ProductType> _typeContext;
        private readonly IGenericRepository<Product> _productContext;
        private readonly IMapper _mapper;
        public ProductController(
            //IProductRepository context, 
            IGenericRepository<ProductBrand> brandContext,                                                  
            IGenericRepository<ProductType> typeContext,
            IGenericRepository<Product> productContext,
            IMapper mapper)
            
        { 
            //_context = context;
            _brandContext = brandContext;
            _typeContext = typeContext;
            _productContext = productContext;
            _mapper = mapper;
        }

        //public ProductController(IProductRepository storeContext)
        //{
        //    _context = storeContext;
        //}
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetProducts()
        {
            var products = await _productContext.GetAllAsync(n => n.ProductType, n => n.ProductBrand);
            var productToReturnList = _mapper.Map<IEnumerable<Product>, List<ProductToReturnDTO>>(products);

            return Ok(productToReturnList);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var product = await _productContext.GetByIdAsync(id, n => n.ProductType, n => n.ProductBrand);
            var productToReturn = _mapper.Map<Product, ProductToReturnDTO>(product);

            return Ok(productToReturn);
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

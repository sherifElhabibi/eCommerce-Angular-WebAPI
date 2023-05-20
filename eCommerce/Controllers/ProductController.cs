using AutoMapper;
using Core.Entities;
using Core.Interfaces;
//using Core.Specifications;
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
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetProducts(string sort,string filter,string search,int pageNumber = 1, int pageSize = 10)
        {
            var products = await _productContext.GetAllAsync(n => n.ProductType, n => n.ProductBrand);
            if (!string.IsNullOrEmpty(filter))
            {
                products = products.Where(p => p.Name.Contains(filter) || p.Description.Contains(filter) || p.ProductType.Name.Contains(filter));
            }
            if (!string.IsNullOrEmpty(search))
            {
                var searchTerm = search.ToLower(); 
                products = products.Where(p => p.Name.ToLower().Contains(searchTerm) || p.Description.ToLower().Contains(searchTerm));
            }
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        products = products.OrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        products = products.OrderByDescending(x => x.Price);
                        break;
                    default:
                        products = products.OrderByDescending(x => x.Name);
                        break;
                }
            }
            var totalCount = products.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedProducts = products.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var productToReturnList = _mapper.Map<IEnumerable<Product>, List<ProductToReturnDTO>>(paginatedProducts);

            return Ok(new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Products = productToReturnList
            });

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

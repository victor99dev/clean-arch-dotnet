using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetProductsAsync();
            if (products == null)
            {
                return NotFound("Products not found");
            }
            
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> Get(Guid? id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound("Products not found");
            }
            
            return Ok(product);
        }

        [HttpPost()]
        public async Task<IActionResult> Post(ProductDTO product)
        {
            if (product == null) return BadRequest("Invalid Data");
            
            await _productService.CreateAsync(product); 

            return new CreatedAtRouteResult("GetProduct", new { Id = product.id}, product);          
        }

        [HttpPut()]
        public async Task<IActionResult> Put(Guid id, ProductDTO product)
        {
            if (id != product.id) return BadRequest();
            if (product == null) return BadRequest();
            
            await _productService.UpdateAsync(product); 

            return Ok(product);          
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound("Product is not found");

            await _productService.RemoveAsync(id);

            return Ok($"Product: {product.id}, deleted successfully");
        }
    }
}
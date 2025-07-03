using Microsoft.AspNetCore.Mvc;
using SmartWatchesAPI.Models.DTOs;
using SmartWatchesAPI.Services.Interfaces;

namespace SmartWatchesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound($"Producto con ID {id} no encontrado");
            }

            return Ok(product);
        }

        // GET: api/Products/category/5
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategory(int categoryId)
        {
            // Verificar que la categoría existe
            if (!await _categoryService.CategoryExistsAsync(categoryId))
            {
                return NotFound($"Categoría con ID {categoryId} no encontrada");
            }

            var products = await _productService.GetProductsByCategoryAsync(categoryId);
            return Ok(products);
        }

        // GET: api/Products/search/{searchTerm}
        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProducts(string searchTerm)
        {
            var products = await _productService.SearchProductsAsync(searchTerm);
            return Ok(products);
        }

        // GET: api/Products/featured
        [HttpGet("featured")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetFeaturedProducts([FromQuery] int count = 6)
        {
            var products = await _productService.GetFeaturedProductsAsync(count);
            return Ok(products);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar que la categoría existe
            if (!await _categoryService.CategoryExistsAsync(updateProductDto.CategoryId))
            {
                return BadRequest($"Categoría con ID {updateProductDto.CategoryId} no encontrada");
            }

            var updatedProduct = await _productService.UpdateProductAsync(id, updateProductDto);

            if (updatedProduct == null)
            {
                return NotFound($"Producto con ID {id} no encontrado");
            }

            return Ok(updatedProduct);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar que la categoría existe
            if (!await _categoryService.CategoryExistsAsync(createProductDto.CategoryId))
            {
                return BadRequest($"Categoría con ID {createProductDto.CategoryId} no encontrada");
            }

            var createdProduct = await _productService.CreateProductAsync(createProductDto);

            return CreatedAtAction("GetProduct", new { id = createdProduct.Id }, createdProduct);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (!result)
            {
                return NotFound($"Producto con ID {id} no encontrado");
            }

            return NoContent();
        }
    }
}
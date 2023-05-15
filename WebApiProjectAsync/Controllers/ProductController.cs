using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProjectAsync.Dto;
using WebApiProjectAsync.Repository;

namespace WebApiProjectAsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductDto productDto)
        {
            var id = await _productRepository.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = id, Controller = "Product" }, id);
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var products = await _productRepository.GetProductByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody]ProductDto productDto, [FromRoute]int id)
        {
            await _productRepository.UpdateProductAsync(id, productDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return Ok();
        }
    }
}

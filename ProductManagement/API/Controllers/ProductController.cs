using Microsoft.AspNetCore.Mvc;
using Services;
using Shared.Exceptions;
using Shared.Products;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _serivce;

        public ProductController(IProductService service) => _serivce = service;

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            try
            {
                var products = await _serivce.GetAllProductsAsync();

                return Ok(products);
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error.");
            }
        }

        [HttpGet("{productGuid:Guid}")]
        public async Task<IActionResult> GetProductByIdAsync(Guid productGuid)
        {
            var product = await _serivce.GetProductByIdAsync(productGuid);

            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(ProductDto product)
        {
            var newProduct = await _serivce.UpdateProductAsync(product);

            return Ok(newProduct);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductDto product)
        {
            product.ProductGuid = Guid.NewGuid();

            var newProduct = await _serivce.AddProductAsync(product);

            return Ok(newProduct);
        }

        [HttpDelete("{productGuid:Guid}")]
        public async Task<IActionResult> DeleteProductAsync(Guid productGuid)
        {
            await _serivce.DeleteProductAsync(productGuid);

            return Ok();
        }
    }
}

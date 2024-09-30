using Microsoft.AspNetCore.Mvc;
using Services;
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
        public IActionResult GetProducts()
        {
            try
            {
                var products = _serivce.GetAllProducts();

                return Ok(products);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error.");
            }
        }

        [HttpGet("{productGuid:Guid}")]
        public IActionResult GetProductById(Guid productGuid)
        {
            var product = _serivce.GetProductById(productGuid);

            return Ok(product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(ProductDto product)
        {
            var newProduct = _serivce.UpdateProduct(product);

            return Ok(newProduct);
        }
    }
}

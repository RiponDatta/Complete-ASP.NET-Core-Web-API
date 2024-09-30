using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _serivce;

        public ProductController(IProductService service) => _serivce = service;

        [HttpGet("getall")]
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

        [HttpGet("get/{productGuid:Guid}")]
        public IActionResult GetProductById(Guid productGuid)
        {
            var product = _serivce.GetProductById(productGuid);

            return Ok(product);
        }
    }
}

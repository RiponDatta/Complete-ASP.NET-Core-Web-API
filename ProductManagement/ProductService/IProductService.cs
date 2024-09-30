using Repository.Models;
using Shared.Products;

namespace Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();

        ProductDto GetProductById(Guid productId);

        Product AddProduct(Product product);

        Product UpdateProduct(Product product);

        void DeleteProduct(Guid productId);
    }
}

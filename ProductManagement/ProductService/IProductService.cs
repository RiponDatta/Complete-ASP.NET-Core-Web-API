using Repository.Models;
using Shared.Products;

namespace Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();

        ProductDto GetProductById(Guid productId);

        Product AddProduct(Product product);

        ProductDto UpdateProduct(ProductDto product);

        void DeleteProduct(Guid productId);
    }
}

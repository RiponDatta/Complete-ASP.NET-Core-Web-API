using Repository.Models;

namespace Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(Guid productId);

        Product AddProduct(Product product);

        Product UpdateProduct(Product product);

        void DeleteProduct(Guid productId);
    }
}

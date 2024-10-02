using Repository.Models;

namespace Repository.Products
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(Guid productGuid);
    }
}

using Repository.Models;

namespace Repository.Products
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(Guid productGuid);
    }
}

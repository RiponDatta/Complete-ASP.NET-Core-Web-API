using Repository.Models;
using Shared.Paging;

namespace Repository.Products
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync(RequestParameter requestParameter);
        Task<Product> GetProductByIdAsync(Guid productGuid);
    }
}

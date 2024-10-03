using Repository.Models;
using Shared.Paging;
using Shared.Products;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(RequestParameter requestParameter);

        Task<ProductDto> GetProductByIdAsync(Guid productId);

        Task<ProductDto> AddProductAsync(ProductDto product);

        Task<ProductDto> UpdateProductAsync(ProductDto product);

        Task DeleteProductAsync(Guid productGuid);
    }
}

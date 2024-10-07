using Repository.Models;
using Shared.Paging;
using Shared.Products;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(RequestParameter requestParameter);

        Task<ProductDto> GetProductByIdAsync(Guid productId, int? versionNumber = null);

        Task<ProductDto> AddProductAsync(ProductDto product);

        Task<ProductDto> UpdateProductAsync(ProductDto product);

        Task DeleteProductAsync(Guid productGuid);
        Task<IEnumerable<ProductTypeDto>> GetProductTypesAsync();
    }
}

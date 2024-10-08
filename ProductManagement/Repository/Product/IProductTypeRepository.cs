using Repository.Models;

namespace Repository.Products
{
    public interface IProductTypeRepository
    {
        ProductType AddProductType(ProductType productType);
        Task<IEnumerable<ProductType>> GetProductTypesAsync();
        Task<ProductType> GetProductTypeByIdAsync(Guid productTypeGuid);
        void UpdateProductType(ProductType existingProductType);
    }
}

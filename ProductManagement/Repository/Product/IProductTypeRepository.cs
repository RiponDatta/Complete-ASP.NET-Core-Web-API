using Repository.Models;

namespace Repository.Products
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetProductTypesAsync();
    }
}

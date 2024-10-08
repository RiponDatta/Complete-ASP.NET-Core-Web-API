using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Products
{
    public class ProductTypeRepository : RepositoryBase<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public ProductType AddProductType(ProductType productType)
        {
            return Create(productType);
        }

        public async Task<ProductType> GetProductTypeByIdAsync(Guid productTypeGuid)
        {
            return await FindByCondition(x => x.ProductTypeGuid == productTypeGuid).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            return await FindAll().OrderBy(x => x.Name).ToListAsync();
        }

        public void UpdateProductType(ProductType existingProductType)
        {
            Update(existingProductType);
        }
    }
}

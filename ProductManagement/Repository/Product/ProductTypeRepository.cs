using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Products
{
    public class ProductTypeRepository : RepositoryBase<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            return await FindAll().OrderBy(x => x.Name).ToListAsync();
        }
    }
}

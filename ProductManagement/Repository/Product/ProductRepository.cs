using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Products
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Product AddProduct(Product product) => Create(product);

        public void DeleteProduct(Product product) => Delete(product);

        public void UpdateProduct(Product product) => Update(product);

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => 
            await FindAll()
            .OrderBy(x => x.Title)
            .ToListAsync();

        public async Task<Product> GetProductByIdAsync(Guid productGuid) => await FindByCondition(x => x.ProductGuid == productGuid).FirstOrDefaultAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Shared.Paging;

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

        public async Task<IEnumerable<Product>> GetAllProductsAsync(RequestParameter requestParameter) => 
            await FindAll()
            .OrderBy(x => x.Title)
            .Skip((requestParameter.PageNumber - 1) * requestParameter.PageSize)
            .Take(requestParameter.PageSize)
            .ToListAsync();

        public async Task<Product> GetProductByIdAsync(Guid productGuid) => await FindByCondition(x => x.ProductGuid == productGuid).FirstOrDefaultAsync();
    }
}

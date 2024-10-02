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

        public IEnumerable<Product> GetAllProducts() => FindAll().OrderBy(x => x.Title).ToList();

        public Product GetProductById(Guid productGuid) => FindByCondition(x => x.ProductGuid == productGuid).FirstOrDefault();
    }
}

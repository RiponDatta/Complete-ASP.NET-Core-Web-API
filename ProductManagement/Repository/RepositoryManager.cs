using Repository.Products;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IProductTypeRepository> _productTypeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            _productTypeRepository = new Lazy<IProductTypeRepository>(() => new ProductTypeRepository(repositoryContext));
        }

        public IProductRepository Product => _productRepository.Value;
        public IProductTypeRepository ProductType => _productTypeRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}

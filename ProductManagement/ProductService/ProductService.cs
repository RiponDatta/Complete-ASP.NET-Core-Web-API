using AutoMapper;
using LoggerService;
using Repository;
using Repository.Models;
using Shared.Exceptions;
using Shared.Products;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
        }

        public ProductDto AddProduct(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);

                var newProduct = _repositoryManager.Product.AddProduct(product);

                _repositoryManager.Save();

                var newProductDto = _mapper.Map<ProductDto>(newProduct);

                return newProductDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(ProductService)}.{nameof(AddProduct)}: {ex}");
                throw;
            }
        }
        public ProductDto UpdateProduct(ProductDto product)
        {
            try
            {
                var existingProduct = _repositoryManager.Product.GetProductById(product.ProductGuid);

                if (existingProduct is null)
                    throw new BadRequestException($"Product Guid: {product.ProductGuid} is not existed.");

                existingProduct.Title = product.Title;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                existingProduct.ProductTypeId = product.ProductTypeId;

                _repositoryManager.Product.UpdateProduct(existingProduct);
                _repositoryManager.Save();

                product = GetProductById(product.ProductGuid);

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(ProductService)}.{nameof(UpdateProduct)}: {ex}");
                throw;
            }
        }

        public void DeleteProduct(Guid productGuid)
        {
            try
            {
                var productToDelete = _repositoryManager.Product.GetProductById(productGuid);

                if(productToDelete is null )
                    throw new BadRequestException($"Product Guid: {productGuid} is not existed.");

                _repositoryManager.Product.DeleteProduct(productToDelete);
                _repositoryManager.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(ProductService)}.{nameof(DeleteProduct)}: {ex}");
                throw;
            }
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            try
            {
                throw new NotFoundException("Error");

                var products = _repositoryManager.Product.GetAllProducts();

                if (products == null)
                    return null;

                var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

                return productsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(ProductService)}.{nameof(GetAllProducts)}: {ex}");
                throw;
            }
        }

        public ProductDto GetProductById(Guid productGuid)
        {
            var product = _repositoryManager.Product.GetProductById(productGuid);

            if (product is null)
                throw new NotFoundException($"Product Guid: {productGuid} doesn't exist.");

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }
        
    }
}

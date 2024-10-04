using AutoMapper;
using LoggerService;
using Repository;
using Repository.Models;
using Shared.Exceptions;
using Shared.Paging;
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

        public async Task<ProductDto> AddProductAsync(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);

                var newProduct = _repositoryManager.Product.AddProduct(product);

                await _repositoryManager.SaveAsync();

                var newProductDto = _mapper.Map<ProductDto>(newProduct);

                return newProductDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(ProductService)}.{nameof(AddProductAsync)}: {ex}");
                throw;
            }
        }
        public async Task<ProductDto> UpdateProductAsync(ProductDto product)
        {
            try
            {
                var existingProduct = await _repositoryManager.Product.GetProductByIdAsync(product.ProductGuid);

                if (existingProduct is null)
                    throw new BadRequestException($"Product Guid: {product.ProductGuid} is not existed.");

                existingProduct.Title = product.Title;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                existingProduct.ProductTypeId = product.ProductTypeId;

                _repositoryManager.Product.UpdateProduct(existingProduct);
                await _repositoryManager.SaveAsync();

                product = await GetProductByIdAsync(product.ProductGuid);

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(ProductService)}.{nameof(UpdateProductAsync)}: {ex}");
                throw;
            }
        }

        public async Task DeleteProductAsync(Guid productGuid)
        {
            try
            {
                var productToDelete = await _repositoryManager.Product.GetProductByIdAsync(productGuid);

                if(productToDelete is null )
                    throw new BadRequestException($"Product Guid: {productGuid} is not existed.");

                _repositoryManager.Product.DeleteProduct(productToDelete);
                await _repositoryManager.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(ProductService)}.{nameof(DeleteProductAsync)}: {ex}");
                throw;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(RequestParameter requestParameter)
        {
            try
            {
                var products = await _repositoryManager.Product.GetAllProductsAsync(requestParameter);

                if (products == null)
                    return null;

                var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

                return productsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(ProductService)}.{nameof(GetAllProductsAsync)}: {ex}");
                throw;
            }
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid productGuid, int? versionNumber = null)
        {
            var product = await _repositoryManager.Product.GetProductByIdAsync(productGuid);

            if (versionNumber != null && versionNumber > 1)
            {
                if (product is null)
                    throw new NotFoundException($"Product Guid: {productGuid} doesn't exist.");
            }

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }
        
    }
}

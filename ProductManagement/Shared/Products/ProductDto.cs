using Repository.Models;

namespace Shared.Products
{
    public class ProductDto
    {
        public Guid ProductGuid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public int ProductTypeId { get; set; }

        public ProductDto ConvertToDto(Product product)
        {
            this.ProductGuid = product.ProductGuid;
            this.Title = product.Title;
            this.Description = product.Description;
            this.Price = product.Price;
            this.Quantity = product.Quantity;
            this.ProductTypeId = product.ProductTypeId;

            return this;
        }
    }
}

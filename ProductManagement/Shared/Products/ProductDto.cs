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
    }
}

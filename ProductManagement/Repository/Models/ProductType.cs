using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid ProductGuid { get; set; }

        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Title { get; set; }

        [StringLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string Description { get; set; }

        public float Price { get; set; }

        public float ActualCost { get; set; }

        public int Quantity { get; set; }

        public int ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; } = null;
    }
}

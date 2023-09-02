using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Industrial.API.Entity
{
    public class Product : BaseEntity
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}

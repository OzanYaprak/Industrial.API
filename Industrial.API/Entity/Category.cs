using System.ComponentModel.DataAnnotations;

namespace Industrial.API.Entity
{
    public class Category : BaseEntity
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public List<Product> Products { get; set; }
    }
}

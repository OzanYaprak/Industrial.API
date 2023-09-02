using System.ComponentModel.DataAnnotations.Schema;

namespace Industrial.API.DTO
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
}

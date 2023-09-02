namespace Industrial.API.DTO
{
    public class EditProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }

        public int CategoryID { get; set; }
    }
}
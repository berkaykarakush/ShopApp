namespace EntityLayer
{
    public class ProductCategory 
    {
        public ProductCategory()
        {
            Random random = new();
            ProductCategoryId = random.Next(111111111, 999999999);
        }
        public double ProductCategoryId { get; set; }
        public double CategoryId { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public Category? Category { get; set; }
        public double ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
